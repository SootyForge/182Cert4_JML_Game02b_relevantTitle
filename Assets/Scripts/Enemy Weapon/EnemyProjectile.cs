using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage = 2f;
    public float speed;
    public float range;

    public GameObject impact;
    public Rigidbody rigid;

    public virtual void Fire(Vector3 direction)
    {
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    public virtual void OnCollisionEnter(Collision collision)
    {
        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        Destroy(gameObject, range);
    }
}
