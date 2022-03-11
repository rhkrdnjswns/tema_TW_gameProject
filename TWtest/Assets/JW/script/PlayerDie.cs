using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))      //플레이어의 PLAYER태그
        {
            if (rb.velocity.y < 0.1f)   //움직이고 있는지 확인
            {
                Debug.Log("사망!");   //사망
            }
        }
    }
}
