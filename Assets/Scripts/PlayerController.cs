using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    #region Player Variables


    #region Movement
    public Rigidbody playerRigid;

    private Vector3 moveDir;

    public float moveSpeed = 5f;

    public float playerMaxBoost;
    public float playerCurBoost;
    public bool boost;
    public bool boostTimeOut;
    #endregion


    #region Health
    public float playerMaxHP;
    public float playerCurHP;

    public bool alive;
    #endregion


    #region Weapon Access
    public Weapon[] weapons;
    private Weapon currentWeapon;
    #endregion

    #region GUI
    private float scrW;
    private float scrH;

    public GUIStyle healthBar;
    public GUIStyle boostBar;
    #endregion
    //    private Interactable interactObject; 
    #endregion

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        playerMaxHP = 100f;
        playerCurHP = playerMaxHP;

        alive = true;

        playerMaxBoost = 100f;
        playerCurBoost = playerMaxBoost;

        boost = false;
        boostTimeOut = false;
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        Vector3 force = new Vector3(moveDir.x, 0f, moveDir.z);

        playerRigid.velocity = force;

        if (playerCurHP == 0)
        {
            SceneManager.LoadScene(0);
        }

        #region TEMPORARY!!! - DELETE THIS, YOU DOOFUS!~
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        } 
        #endregion
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

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerCurHP > playerMaxHP)
            playerCurHP = playerMaxHP;

        if (playerCurHP < 0 || !alive)
            playerCurHP = 0;

        if (alive && playerCurHP == 0)
        {
            alive = false;
        }



        if (playerCurBoost > playerMaxBoost)
            playerCurBoost = playerMaxBoost;

        if (playerCurBoost < 0)
        {
            playerCurBoost = 0;
            boost = false;
        }

        if (playerCurBoost < playerMaxBoost && !boost)
            boostTimeOut = true;

        if (boostTimeOut)
            boost = false;

        if (playerCurBoost == playerMaxBoost)
            boostTimeOut = false;
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
//            playerRigid.AddRelativeForce(100f, 0f, 100f, ForceMode.Impulse);
            playerRigid.AddForce((transform.position - collision.contacts[0].point) * 7500f);
            playerCurHP -= 10f;
        }
        if(collision.transform.tag == "Pickup_HP")
        {
            playerCurHP += 10f;
        }
    }

    public void Move(float inputH, float inputV)
    {
        moveDir = new Vector3(inputH, 0f, inputV);
        moveDir *= moveSpeed;
    }

    public void Boost()
    {
        if (boost)
        {
            moveSpeed = 12f;
            playerCurBoost -= Time.deltaTime * 50f;
        }

        else
        {
            moveSpeed = 8f;
            playerCurBoost += Time.deltaTime * 40f;
        }
    }

    // OnGUI is called for rendering and handling GUI events
    private void OnGUI()
    {
        scrW = Screen.width / 16f;
        scrH = Screen.height / 9f;

        GUI.Box(new Rect(0.5f * scrW, 0.25f * scrH, 4 * scrW, 0.5f * scrH), "");
        GUI.Box(new Rect(0.5f * scrW, 0.25f * scrH, playerCurHP * (4 * scrW) / playerMaxHP, 0.5f * scrH), "", healthBar);

        GUI.Box(new Rect(11f * scrW, 0.25f * scrH, 4 * scrW, 0.5f * scrH), "", healthBar);
        GUI.Box(new Rect(11f * scrW, 0.25f * scrH, playerCurBoost * (4 * scrW) / playerMaxBoost, 0.5f * scrH), "", boostBar);
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




    // OnTriggerEnter is called when the Collider other enters the trigger
    //    private void OnTriggerEnter(Collider other)
    //    {
    //        interactObject = other.GetComponent<Interactable>();
    //    }


}
