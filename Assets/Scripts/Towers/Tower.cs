using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour,TowerInterface
{

    GameObject bulletToShoot;

    [SerializeField]
    GameObject Muzzle;

    [SerializeField]
    TowerData towerData;

    public float shootRate;

    public float damage;
    float oldDamage;

    bool enemyFound = true;

    public List<GameObject> enemyList;

    void Start()
    {
        enemyList = new List<GameObject>();

        bulletToShoot = towerData.bulletToShoot;
        shootRate = towerData.shootRate;
        damage = towerData.damage;
        oldDamage = damage;

        //coroutine per lo shooting
        StartCoroutine(Shoot());

    }

    private void Update()
    {

        if (shootRate <= 0) 
        {
            shootRate = 0.1f;
        }

        //funzione che trova l'enemy
        FindEnemy();


        //controllo per essere sicuri di aumentare il danno
        if (damage != oldDamage) 
        {
            Bullet bullet = bulletToShoot.GetComponent<Bullet>();

            bullet.SetBulletDamage(damage);
        }
    }

    //se un enemy entra nel range della torretta viene aggiunto nella list
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !enemyList.Contains(other.gameObject))
        {
            enemyList.Add(other.gameObject);
        }
    }

    //se un enemy esce dal range esce anche dalla lista
    void OnTriggerExit(Collider other)
    {
        enemyList.Remove(other.gameObject);
    }

    public void FindEnemy() 
    {
        foreach (GameObject enemy in enemyList)
        {
            if (!enemy) return;

            //controllo se l'enemy è ancora attivo
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
