using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    [SerializeField]
    float BarrierHP;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            BarrierHP -= 50;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (BarrierHP <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
