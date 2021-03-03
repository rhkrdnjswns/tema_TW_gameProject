using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지에 블록을 생성해줌
public class SpawnerTetris : MonoBehaviour
{
    public GameObject[] Tetris; //생성할 테트리스 블록 담을 게임옵젝 변수
    public GameObject currentTetris; //생성된 블록을 담는 변수
    public float xPos;// 이전에 생성된 블록의 위치 검사 (2개 이상 생성 시 중복 방지)
    public float zPos;
    public GameObject[] TetrisGhost; //생성할 테트리스 블록의 고스트를 담을 게임옵젝 변수
    public GameObject currentTetrisGhost; //생성된 블록의 고스트를 담는 변수

    public int level = 1; //블록 떨어지는 갯수

    [SerializeField]
    private float[] Angle;

    //public float difficulty = 10;
    //int[] posX = new int[2];
    //int[] posZ = new int[2];
    List<int> PosX = new List<int>();
    List<int> PosZ = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

        //NewTetris();

    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.B))
        {
            if (PosX != null && PosZ != null)
            {
                for (int i = 0; i < PosX.Count; i++)
                {
                    Debug.Log(PosX[i]);
                    Debug.Log(PosZ[i]);
                }
            }
          
        }*/
           
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewTetris(); //스페이스바 누르면 호출
            
            
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            level++; //G키 누르면 레벨 하나씩 오름
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < tetrisblock.X; i++)
            {
                for (int j = 0; j < tetrisblock.Z; j++)
                {
                    //int blockNum = Random.Range(0, Tetris.Length);
                    transform.position = new Vector3(i, transform.position.y, j);
                    currentTetris = Instantiate(Tetris[0], transform.position, Quaternion.identity);
                    currentTetrisGhost = Instantiate(TetrisGhost[0], transform.position, Quaternion.identity);
                    currentTetrisGhost.GetComponent<Ghost>().tblock = currentTetris;
                }
            }
        }
    }
    public void NewTetris() //새 블록을 생성하는 함수
    {
        //CreateRandomPos(0, 6);
        
        for (int i = 0; i < level; i++)// 레벨에 따라서 생성되는 블록 갯수가 올라감
            {

                int Rpos = Random.Range(0, 2);
                int blockNum = Random.Range(0, Tetris.Length); //난수 생성 후 변수에 할당
              //transform.position = new Vector3(PosX[i], transform.position.y, PosZ[i]);//for문 돌때마다 스테이지 내에서 랜덤한 범위로 스포너 위치 이동
                transform.position = new Vector3(Rpos, transform.position.y, Rpos);
            
                currentTetris = Instantiate(Tetris[blockNum], transform.position, Quaternion.Euler(Angle[Random.Range(0, Angle.Length)], Angle[Random.Range(0, Angle.Length)], Angle[Random.Range(0, Angle.Length)]));//게임옵젝 배열의 랜덤한 번째 블록을 생성
                currentTetrisGhost = Instantiate(TetrisGhost[blockNum], transform.position, currentTetris.transform.rotation) ;//게임옵젝 배열의 랜덤한 번째 고스트 생성
                
                currentTetrisGhost.GetComponent<Ghost>().tblock = currentTetris;
                Debug.Log("넣음");
            //if (currentTetrisGhost.GetComponent<Ghost>().tBlock == null) continue;
            xPos = transform.position.x;
            zPos = transform.position.z;
        }

        //PosX.Clear();
        //PosZ.Clear();
    }
    /*void SetRandomValue() // 난수가 겹치는 현상 막는 함수
    {
        List<int> posValueX = new List<int>();
        List<int> posValueZ = new List<int>();

        bool flag = true;
        int randomX = Random.Range(0, 3);
        int randomZ = Random.Range(0, 3);

        if(posValueX.Count > 0 || posValueZ.Count > 0)
        {
            for (int i = 0; i < posValueX.Count; i++)
            {
                if (posValueX[i] == randomX)
                {
                    //SetRandomValue
                }
            }
            

           
        }
    }*/
    void CreateRandomPos(int min, int max)
    {
        int currentNumberX = Random.Range(min, max);
        int currentNumberZ = Random.Range(min, max);
        
            for (int i = 0; i < max;)
            {
                if (PosX.Contains(currentNumberX))
                {
                    currentNumberX = Random.Range(min, max);
                }
                
                    PosX.Add(currentNumberX);
                    i++;
                


            }
            for (int i = 0; i < max;)
            {
                if (PosZ.Contains(currentNumberZ))
                {
                    currentNumberZ = Random.Range(min, max);
                }
                
                    PosZ.Add(currentNumberZ);
                    i++;
                
            }
            
            for (int i = 0; i < max; i++)
            {              
                Debug.Log(PosX[i]);
                Debug.Log(PosZ[i]);
            }
            /*for(int i = 0; i<max-1;)
            {
            
                if (PosX[i] == PosX[i+1] && PosZ[i] == PosZ[i+1])
                {
                    CreateRandomPos(0, 2);
                }
                else
                {
                    return;
                }
            }*/
       
    }
   /* void CreateRandom(int min, int max)
    {
        int currentNumberX = Random.Range(min, max);
        int currentNumberZ = Random.Range(min, max);

        for (int i = 0; i < max;)
        {
            if (posX[i] == currentNumberX)
            {
                currentNumberX = Random.Range(min, max);
            }
            else
            {
                posX[i] = currentNumberX;
                i++;
            }


        }
        for (int i = 0; i < max;)
        {
            if (posZ[i] == currentNumberZ)
            {
                currentNumberZ = Random.Range(min, max);
            }
            else
            {
                posZ[i] = currentNumberZ;
                i++;
            }
        }
        /*for (int i = 0; i < max; i++)
        {
            Debug.Log(PosX[i]);
            Debug.Log(PosZ[i]);
        }


    }*/
}
