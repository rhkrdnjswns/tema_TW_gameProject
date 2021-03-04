using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지에 블록이 쌓이는 기능을 담당
public class tetrisblock : MonoBehaviour
{
    //private float previousTime;
    //public float fallTime = 1.0f;
    public  static int X = 2;//스테이지 X축 범위
    public  static int Z = 2; // 스테이지 Z축 범위
    public static int Y = 14; //스테이지 Y축 범위

    public static Transform[,,] grid = new Transform[Z, X, Y]; //스테이지 전체의 위치를 저장할 배열
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        foreach(Transform children in transform) // 인자값을 싹다 검사할때까지 true 블록 오브젝트의 자식오브젝트들 검사. 현재 해당 스크립트가 들어있는 블록의 자식객체들 트랜스폼 검사
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x); // 블록 오브젝트를 구성하는 자식객체들의 월드포지션을 정수값으로 반올림하여 할당
            int roundZ = Mathf.RoundToInt(children.transform.position.z); // 블록 오브젝트를 구성하는 자식객체들의 월드포지션을 정수값으로 반올림하여 할당
            if (roundZ >= Z) //할당받은 자식객체들의 x,z값 중에서 스테이지 범위를 벗어난 블록이 있으면 벗어난만큼 빼준다.
            {
                transform.position += new Vector3(0, 0, -1);

            }
            else if (roundZ < 0)
            {
                transform.position += new Vector3(0, 0, 1);

            }
            else if(roundX >= X)
            {
                transform.position += new Vector3(-1, 0, 0); 
            }
            else if (roundX < 0)
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        //rig.velocity = new Vector3(0, -0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, 0, 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, 0, -1);
            }

        }*/
        /*if (Time.time - previousTime > (Input.GetKey(KeyCode.Space) ? fallTime / 10 : fallTime))
        {
            
            transform.position += new Vector3(0, -1f, 0);
            previousTime = Time.time;
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1f, 0);
                AddToGrid();
                CheckForLines();

                this.enabled = false;
                FindObjectOfType<SpawnerTetris>().NewTetris();
            }
        
       
        }*/
        /*if(this.gameObject.transform.childCount == 0)
        {
            Destroy(this.gameObject); // 블록의 자식객체가 없을 때(빈게임옵젝만 남았을 때) 빈게임옵젝 삭제
        }*/
        
        if (!ValidMove()) // 불리언 함수 -> false일 때 실행 됨.
        {
            
            AddToGrid(); // 트랜스폼 배열에 블록 저장
            
            CheckForLines(); // 해당 층이 비었는지 검사 후 층 클리어 및 윗 블록 아래로 옮김.
            
            this.enabled = false; //해당 스크립트의 기능 비활성화.
            
            //FindObjectOfType<SpawnerTetris>().NewTetris();
           
        }

    }
    void CheckForLines()
    {
        for (int i = Y-1; i >= 0; i--) //맨 윗층부터 한층씩 밑으로 가면서 검사
        {
            if (HasLine(i)) // 해당 불리언 함수가 true면 실행
            {
                
                DeleteLine(i);  //줄 삭제 함수     
                RowDown(i); //한 줄 밑으로 당기는 함수
                
            }
        }
    }
     
    bool HasLine(int i)// Y축을 기준으로 z,x축에 블록이 있는지 검사, 한칸이라도 비어있으면 false 리턴
    {
        for (int j = 0; j < Z; j++) //스테이지의 Z축 범위만큼 0부터 검사
        {
            for(int k = 0; k <X; k++) //스테이지의 X축 범위만큼 0부터 검사
            {
                if(grid[j,k,i] == null)
                {
                    return false;
                }
            }            
        }
        return true;
    }
    void DeleteLine(int i) // Y축을 기준으로 z,x축의 블록을 차례대로 삭제시키고 배열을 비워줌.
    {
        for(int j = 0; j < Z; j++) //스테이지의 Z축 범위만큼 0부터 검사
        {
            for (int k = 0; k < X; k++) //스테이지의 X축 범위만큼 0부터 검사
            {
                Destroy(grid[j, k, i].gameObject); //해당 위치의 오브젝트 없앰
                if(grid[j,k,i].gameObject.transform.parent.gameObject.transform.childCount == 0)
                {
                    Destroy(grid[j, k, i].gameObject.transform.parent);
                }               
                grid[j, k, i] = null; // 해당 위치의 배열 비워줌
               
            }
        } 
    }
    void RowDown(int i) // 한 층이 클리어됐을 때 위에있는 블록들을 한 층 내려줌.
    {
        for (int y = i; y < Y; y++) //y축을 i층에서부터 위로 올라가면서 검사
        {
            for (int z = 0; z < Z; z++)//스테이지의 Z축 범위만큼 0부터 검사
            {
                for(int x = 0; x<X; x++)//스테이지의 X축 범위만큼 0부터 검사
                {
                    if(grid[z,x,y] != null) //해당 층에 오브젝트가 들어있을 때
                    {
                        //Vector3 TargetPos = new Vector3(grid[z, x, y].transform.position.x, grid[z, x, y].transform.position.y, grid[z, x, y].transform.position.z);
                        grid[z, x, y - 1] = grid[z, x, y]; //해당 층 배열에 담긴 오브젝트들을 한층 밑의 배열에 옮겨줌
                       
                        grid[z, x, y] = null; //옮긴 후 해당 배열 비워줌.

                        //grid[z, x, y - 1].transform.position -= new Vector3(0, -1, 0);
                            //Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2f);
                    }
                }
            }
        }
    }
    void AddToGrid() //3차원 배열 grid에 블록을 저장함
    {
        foreach(Transform children in transform) //자식객체의 트랜스폼들을 순서대로 받아옴.
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);//자식객체들의 포지션x값을 반올림해서 정수형으로 넣어줌.
            int roundZ = Mathf.RoundToInt(children.transform.position.z);//자식객체들의 포지션z값을 반올림해서 정수형으로 넣어줌.
            int roundY = Mathf.RoundToInt(children.transform.position.y);//자식객체들의 포지션y값을 반올림해서 정수형으로 넣어줌.
            //float roundY = children.transform.position.y;
            /*if(roundY < 1)
            {
                roundY = 1;
            }*/
            //int roundYtoInt = Mathf.RoundToInt((float)roundY);
            grid[roundX, roundZ, roundY] = children;
            
            /*if(children.position.y == roundY)
            {
                rig.isKinematic = true;
            }*/
            Debug.Log(roundX.ToString() + roundY.ToString() + roundZ.ToString());
            //Debug.Log
            //grid[roundX, roundZ, roundY].transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            /*if (rig != null)
            {
                DestroyImmediate(rig);
            }*/
        }
    }
    public bool ValidMove() // 블록이 땅 혹은 다른 블록 위에 쌓였는가를 반환해주는 불리언 함수.
    {
        foreach(Transform children in transform)//해당 블록의 자식객체들의 트랜스폼을 하나씩 받아옴.
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x); //자식객체들의 포지션x값을 반올림해서 정수형으로 넣어줌.
            int roundZ = Mathf.RoundToInt(children.transform.position.z); //자식객체들의 포지션z값을 반올림해서 정수형으로 넣어줌.
            int roundY = Mathf.RoundToInt(children.transform.position.y); //자식객체들의 포지션y값을 반올림해서 정수형으로 넣어줌.

            //float roundY = children.transform.position.y;
            //int roundYtoInt = Mathf.RoundToInt((float)roundY);
            if (roundX < 0 || roundX >= X || roundZ < 0 || roundZ >= Z || roundY <= 1 || roundY >= Y)
            {
                return false;
            }
            if(grid[roundX,roundZ, roundY-1] != null)
            {
                
                return false;
            }
        }
        return true;
    }
}
