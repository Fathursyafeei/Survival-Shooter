using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor"); //Mendapatkan nilai mask dari layer yang bernama Floor

        anim = GetComponent<Animator>(); // Mendapatkan komponen Animator
        
        playerRigidbody = GetComponent<Rigidbody>(); // Mendapatkan komponen Rigidbody
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");  // Mendapatkan nilai input horizontal (-1,0,1)

        float v = Input.GetAxisRaw("Vertical"); // Mendapatkan nilai input vertical (-1,0,1)

        Move(h, v);
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    //Method player dapat berjalan
    void Move(float h, float v)
    {  
        movement.Set(h, 0f, v); // Set nilai x dan y
  
        movement = movement.normalized * speed * Time.deltaTime; // Menormalisasi nilai vector agar total panjang dari vector adalah 1

        playerRigidbody.MovePosition(transform.position + movement); //Move to position
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // Buat Ray dari posisi mouse di layar

        RaycastHit floorHit; // Buat raycast untuk floorHit

        //Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position; // Mendapatkan vector daro posisi player dan posisi floorHit
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse); //Mendapatkan look rotation baru ke hit position

            playerRigidbody.MoveRotation(newRotation);  // Rotasi player
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
