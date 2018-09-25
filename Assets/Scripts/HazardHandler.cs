using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHandler : MonoBehaviour
{
    public float flashTime = 1f;
    public float hazHP;

    Color origionalColor;
    public MeshRenderer rend;

    void Start()
    {
        if (gameObject.transform.tag == "Obstacle")
            hazHP = 10f;
        rend = GetComponent<MeshRenderer>();
        origionalColor = rend.material.color;
    }
    void FlashRed()
    {
        rend.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        rend.material.color = origionalColor;
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile_Player")
        {
            FlashRed();
            hazHP--;
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        if (hazHP <= 0f)
        {
            Destroy(gameObject);
        }
    }




}
