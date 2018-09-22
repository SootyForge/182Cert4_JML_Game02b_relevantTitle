using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage;
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

}
