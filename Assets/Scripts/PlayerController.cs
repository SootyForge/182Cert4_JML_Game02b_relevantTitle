using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid;

    //    private float inputX;
    //    private float inputZ;

    public float moveSpeed = 5f;
    public bool boost;

    public Weapon[] weapons;
    private Weapon currentWeapon;
    private Vector3 moveDir;
//    private Interactable interactObject;

    // OnTriggerEnter is called when the Collider other enters the trigger
//    private void OnTriggerEnter(Collider other)
//    {
//        interactObject = other.GetComponent<Interactable>();
//    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        Vector3 force = new Vector3(moveDir.x, 0f, moveDir.z);

        playerRigid.velocity = force;
    }

    private void DisableAllWeapons()
    {
        // Loop through every weapon
        foreach (Weapon weapon in weapons)
        {
            // Deactivate weapon's GameObject
            weapon.gameObject.SetActive(false);
        }
    }

    public void SelectWeapon(int index)
    {
        // Check index is within range of weapons array
        // is within range i >= 0 && i < length
        // is not within range i < 0 && i >= length
        if (index < 0 || index >= weapons.Length)
            return;

        // DisableAllWeapons
        DisableAllWeapons();

        // Enable weapon at index
        weapons[index].gameObject.SetActive(true);

        // Set the currentWeapon
        currentWeapon = weapons[index];
    }

    //    // Update is called once per frame
    //    void LateUpdate()
    //    {
    //        inputX = Input.GetAxis("Horizontal");
    //        inputZ = Input.GetAxis("Vertical");
    //
    //        playerRigid.velocity = new Vector3(inputX, 0, inputZ) * speed;
    //
    //        if (Input.GetKey(KeyCode.LeftShift))
    //        {
    //            speed = 8f;
    //        }
    //        else
    //        {
    //            speed = 5f;
    //        }
    //    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    public void Move(float inputH, float inputV)
    {
        moveDir = new Vector3(inputH, 0f, inputV);
        moveDir *= moveSpeed;
    }
    public void Attack()
    {
        currentWeapon.Attack();
    }
//    public void Interact()
//    {
//        // If interactable is found
//        if (interactObject)
//        {
//            // Run interact
//            interactObject.Interact();
//        }
//    }


}
