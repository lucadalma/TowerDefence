using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float enemyHP;

    [SerializeField]
    List<Transform> pointList;

    [SerializeField]
    float enemySpeed;

    private int moveIndex = 0;
    public bool isLoop = true;

    Spawner spawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            Debug.Log("colpito");
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            enemyHP -= bullet.bulletDamage;
        }
    }

    void Start()
    {
        GameObject enemyPath = GameObject.FindGameObjectWithTag("Path");
        spawner = FindAnyObjectByType<Spawner>();


        foreach (Transform point in enemyPath.GetComponentsInChildren<Transform>())
        {
            if (point.CompareTag("Point")) 
            {
                pointList.Add(point);
            }
        }

        if (spawner.countSpawner >= 15)
        {
            enemyHP = 200;
            enemySpeed = 3;
        }

    }

    void Update()
    {

        if (enemyHP <= 0) 
        {
            gameObject.SetActive(false);
        }


        Vector3 destination = pointList[moveIndex].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, enemySpeed * Time.deltaTime);
        transform.position = newPos;
        transform.LookAt(destination);

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (moveIndex < pointList.Count - 1)
            {
                moveIndex++;
            }
            else 
            {
                if (isLoop) 
                {
                    moveIndex = 0;
                }
            }
        }
    }
}
