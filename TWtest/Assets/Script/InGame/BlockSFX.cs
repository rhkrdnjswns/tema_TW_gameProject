using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSFX : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            if(SoundManager.Instance != null)
            {
                int rand = Random.Range(2, 4);
                SoundManager.Instance.PlaySound(false, rand);
            }           
        }
    }
}
