using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public Sprite Block;
    public Sprite Tile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Block")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Block;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        Debug.Log("Exit");
        if (coll.gameObject.tag == "Block")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Tile;     //충돌이 해제될때 비활성화를 먼저 하고 블럭을 킵할시에 충돌해제를 함수가 체크하지
                                                                                   //못하므로 블럭이 활성화 상태일때 충돌해제(transform.position등으로)를 먼저 해야한다.
        }
    }
}
