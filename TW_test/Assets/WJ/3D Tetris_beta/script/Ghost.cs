using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//블록이 떨어질 위치를 보여주는 고스트를 관리함

public class Ghost : MonoBehaviour
{
    //public GameObject pivot;
    
    
    public tetrisblock tBlock; // 테트리스블록 객체
    public GameObject tblock;
    // Start is called before the first frame update
    void Start()
    {      
        
        var SP = GameObject.FindGameObjectWithTag("Spawner"); // 지역변수 SP에 스포너 할당
        //var cBlock = SP.GetComponent<SpawnerTetris>().currentTetris; // 스포너 안에있는 클래스의 currentTetris필드 할당.
        
        
        tBlock = tblock.GetComponent<tetrisblock>(); // 현재 생성된 블럭의 클래스 할당
        Debug.Log("할당했어");
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x); 
            int roundZ = Mathf.RoundToInt(children.transform.position.z); 
            if (roundZ >= tetrisblock.Z) 
            {
                transform.position += new Vector3(0, 0, -1);

            }
            else if (roundZ <0 )
            {
                transform.position += new Vector3(0, 0, 1);
            }
            else if (roundX >= tetrisblock.X)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (roundX <0 )
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
            //transform.rotation = cBlock.transform.rotation; //생성된 고스트의 회전값을 현재 생성된 블록의 회전값과 동일하게 해줌.
            //transform.position = cBlock.transform.position;
        
               
        //var Y = new Vector3(transform.position.x, 1, transform.position.z);
        //transform.position = Y;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
        while (isVlidGridPos()) // 해당 불리언 변수가 트루일동안 계속 반복
        {
            transform.position += new Vector3(0, -1, 0); //고스트의 y축 위치를 밑으로 1칸씩 계속 내려줌
        }
        transform.position += new Vector3(0, 1, 0); // 고스트의 y축 위치를 한칸 위로 올림
        //transform.position += new Vector3(0, 1, 0);
        if(tBlock != null) // tBlock이 안비어있을때(커렌트 테트리스가 있을 때만)
        {
            if (!tBlock.ValidMove()) //커렌트 테트리스의 발리드무브가 false일 때
            {
                Destroy(this.gameObject); // 해당 고스트 삭제
            }
        }
        
    }
    bool isVlidGridPos()
    {
        foreach(Transform children in transform) //고스트 블록의 자식객체 블록들의 트랜스폼 하나씩 받아옴
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x); //고스트의 자식객체의 월드포지션 x 반올림
            int roundZ = Mathf.RoundToInt(children.transform.position.z);//고스트의 자식객체의 월드포지션 z 반올림
            int roundY = Mathf.RoundToInt(children.transform.position.y);//고스트의 자식객체의 월드포지션 y 반올림
            //if (children.tag != "Pivot") 
            //{ 
               if (roundX < 0 || roundX >= tetrisblock.X || roundZ < 0 || roundZ >= tetrisblock.Z || roundY <= 0 || roundY >= 14) //고스트의 자식객체가 스테이지 범위를 벗어나면 false
            {
                return false;
            }          
            
                var SP = GameObject.FindGameObjectWithTag("Spawner"); // 지역변수 SP에 스포너를 넣어줌
            
                var cBlock = SP.GetComponent<SpawnerTetris>().currentTetris; // 현재 생성된 블럭을 변수에 할당


                if (tetrisblock.grid[roundX, roundZ, roundY] != null) // 고스블록의 현재 위치에 테트리스 블록이 있다면
                {
                    if (tetrisblock.grid[roundX, roundZ, roundY].parent != cBlock.transform) // 고스트블록의 현재 위치에 있는 오브젝트가  현재 생성된 블록이 아니면
                        return false;
                }
            
               
            //}
            
        }
        return true;//다 해당사항 없으면 true 리턴
    }
}
