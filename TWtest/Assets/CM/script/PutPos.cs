using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPos : MonoBehaviour
{
    public Vector3 pos;// 자기위치 
    // Start is called before the first frame update
  
    void Update()
    {
        pos = this.gameObject.transform.position;//자신의 위치 계속 초기화
    }
    
}

