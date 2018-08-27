using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Player Controller zur Steuerung der Spielfigur.
 * Verknüpfung mit dem Damage Script ( Knockback ).
 * 
 * 
 * Marc Rosenkranz - 143025
 * */

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 10;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;
    private Vector3 moveDirection;
    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;
    public GameObject model;

    public float hitByEnemy;
    public float hitTime;
    private float hitCounter;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        //hitCounter zur Steuerung des Knockbacks bei Gegnerkontakt
        if (hitCounter <= 0) {                                                                                             
        
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical") + (transform.right * Input.GetAxis("Horizontal")));
        moveDirection = moveDirection.normalized * moveSpeed;  //keine Geschwindigkeitserhöhung bei W+S || W+A usw.                                                              
        moveDirection.y = yStore; //keine Veränderung auf der Y-Achse - Spielfigur "fliegt" nicht

        if (Input.GetKey(KeyCode.LeftShift))  
        {
            moveSpeed = 20; //Sprinten - durch Erhöhung der movementSpeeds
            }
        else
        {
            moveSpeed = 10;
        }

            if (controller.isGrounded)  //Prüfen ob spieler "grounded" ist                                                                                    
            {
                moveDirection.y = 0f;   //Spielfigur läuft immer auf dem Boden
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce; //Manipulation der moveDirection auf der Y-Achse - Spielfigur springt.
                }
            }

        if (!isGrounded) //sliden wenn slopeLimit
        {
            moveDirection.x += (1f - hitNormal.y) * hitNormal.x * (moveSpeed - slideFriction);
            moveDirection.z += (1f - hitNormal.y) * hitNormal.z * (moveSpeed - slideFriction);
        }

        } else
            {
                hitCounter -= Time.deltaTime;
            }
		
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        //Verschiedene Richtungen X & Z Achse mit smoother Rotation des Spielermodels
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newRotation, rotateSpeed * Time.deltaTime); //smoothe Rotation
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical") + Mathf.Abs(Input.GetAxis("Horizontal")))); //Animation des Spielermodels
    }

    public void Knockback(Vector3 direction)
    {
        hitCounter = hitTime;

        direction = new Vector3(1f, 15f, 3f);   //Richtung des Knockbacks

        moveDirection = direction * hitByEnemy; //Manipulation der movedirection bei Knockback
        
    }
}
