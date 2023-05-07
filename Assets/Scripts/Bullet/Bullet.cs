using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float bulletSpeed;

    public float bulletDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void SetBulletDamage(float _damage) 
    {
        bulletDamage = _damage;
    }
}
