using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    [SerializeField]
    float BarrierHP;

    GameManager gm;

    private void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //la barriera perde vita
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
            gm.gameStatus = GameStatus.GameOver;
            Destroy(gameObject);
        }
    }
}
