using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        //Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;

    }

    private void Update()
    {
        // Jika terkena damage
        if (damaged)
        {
            damageImage.color = flashColour; // Merubah warna gambar menjadi value dari flashColour

        }
        else
        {
            // Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Set damage to False
        damaged = false;
    }

    // function untuk mendapatkan damage.
    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount; // Mengurangi health

        healthSlider.value = currentHealth; //Merubah tampilan dari health slider.

        playerAudio.Play();

        // Memanggil method Death() jika darahnya kurang atau sama dengan 0 dan belum mati.
        if(currentHealth <=0 && !isDead)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        //playerShooting.DisableEffects();

        anim.SetTrigger("Die"); // Mentrigger animasi Die/

        //Memainkan suara ketika mati.
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false; // Mematikan script player movement

        //playerShooting.enable = false;
    }

    public void RestartLeve()
    {
        SceneManager.LoadScene(0); // Meload ulang scene dengan index 0 pada build setting.
    }
}


//public int startingHealth = 100;
//public int currentHealth;
//public Slider healthSlider;
//public Image damageImage;
//public AudioClip deathClip;
//public float flashSpeed = 5f;
//public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


//Animator anim;
//AudioSource playerAudio;
//PlayerMovement playerMovement;
////PlayerShooting playerShooting;
//bool isDead;                                                
//bool damaged;                                               


//void Awake()
//{
//    anim = GetComponent<Animator>();
//    playerAudio = GetComponent<AudioSource>();
//    playerMovement = GetComponent<PlayerMovement>();
//    //playerShooting = GetComponentInChildren<PlayerShooting>();

//    currentHealth = startingHealth;
//}


//void Update()
//{
//    if (damaged)
//    {
//        damageImage.color = flashColour;
//    }
//    else
//    {
//        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
//    }

//    damaged = false;
//}


//public void TakeDamage(int amount)
//{
//    damaged = true;

//    currentHealth -= amount;

//    healthSlider.value = currentHealth;

//    playerAudio.Play();

//    if (currentHealth <= 0 && !isDead)
//    {
//        Death();
//    }
//}


//void Death()
//{
//    isDead = true;

//    //playerShooting.DisableEffects();

//    anim.SetTrigger("Die");

//    playerAudio.clip = deathClip;
//    playerAudio.Play();

//    playerMovement.enabled = false;
//    //playerShooting.enabled = false;
//}