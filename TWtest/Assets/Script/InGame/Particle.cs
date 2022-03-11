using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BlockO" || collision.gameObject.tag == "BlockI"|| 
            collision.gameObject.tag == "BlockminiI"|| collision.gameObject.tag == "BlockR")
        {
            particle.Play();
        }
    }
}
