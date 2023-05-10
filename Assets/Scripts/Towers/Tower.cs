using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField]
    public GameObject bulletToShoot;

    [SerializeField]
    GameObject Muzzle;

    [SerializeField]
    public float shootRate;

    [SerializeField]
    public float damage;
    private float oldDamage;

    bool enemyFound = true;

    public List<GameObject> enemyList;

    void Start()
    {
        enemyList = new List<GameObject>();

        oldDamage = damage;

        StartCoroutine(Shoot());

    }

    private void Update()
    {
        if (shootRate <= 0) 
        {
            shootRate = 0.1f;
        }


        FindEnemy();

        if (damage != oldDamage) 
        {
            Bullet bullet = bulletToShoot.GetComponent<Bullet>();

            bullet.SetBulletDamage(damage);
        }

        //if (Time.time > nextActionTime && enemyFound == true)
        //{
        //    Instantiate(bulletToShoot, Muzzle.transform.position, gameObject.transform.localRotation);
        //    nextActionTime += shootRate;
        //    Debug.Log("Sparo");
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !enemyList.Contains(other.gameObject))
        {
            enemyList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        enemyList.Remove(other.gameObject);
    }

    public void FindEnemy() 
    {
        foreach (GameObject enemy in enemyList)
        {
            if (!enemy) return;

            if (enemy.activeSelf == false)
            {
                enemyFound = false;
                enemyList.Remove(enemy);
            }
            else if (enemy.activeSelf == true) 
            {
                enemyFound = true;
                transform.LookAt(enemy.transform);
            }

        }
    }


    IEnumerator Shoot()
    {
        while (true)
        {
            if(enemyFound)
                Instantiate(bulletToShoot, Muzzle.transform.position, gameObject.transform.localRotation);
            
            yield return new WaitForSeconds(shootRate);
        }
    }
}
