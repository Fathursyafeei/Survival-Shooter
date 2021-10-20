using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider casuleCollider;
    bool isDead;
    bool isSinking;


    private void Awake()
    {
        // Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        casuleCollider = GetComponent<CapsuleCollider>();

        // Set Current Health
        currentHealth = startingHealth;
    }
    private void Update()
    {
        // Check Sinking
        if (isSinking)
        {
            // Memindahkan objek kebawah
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // check Jika mati
        if (isDead)
            return;

        // play Audio
        enemyAudio.Play();

        // Kurangi Health 
        currentHealth -= amount;

        // Ganti posisi particle
        hitParticles.transform.position = hitPoint;

        // Play particle system
        hitParticles.Play();

        // Dead jika health <= 0 
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        // Set isDeath
        isDead = true;

        //SetCollider ke trigger
        casuleCollider.isTrigger = true;

        // trigger play Animation Dead 
        anim.SetTrigger("Dead");

        // Play Sound Dead
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        // Disable Navmesh Component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Set Rigidbody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}


//public int startingHealth = 100;
//public int currentHealth;
//public float sinkSpeed = 2.5f;
//public int scoreValue = 10;
//public AudioClip deathClip;


//Animator anim;
//AudioSource enemyAudio;
//ParticleSystem hitParticles;
//CapsuleCollider capsuleCollider;
//bool isDead;
//bool isSinking;


//void Awake()
//{
//    anim = GetComponent<Animator>();
//    enemyAudio = GetComponent<AudioSource>();
//    hitParticles = GetComponentInChildren<ParticleSystem>();
//    capsuleCollider = GetComponent<CapsuleCollider>();

//    currentHealth = startingHealth;
//}


//void Update()
//{
//    if (isSinking)
//    {
//        transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
//    }
//}


//public void TakeDamage(int amount, Vector3 hitPoint)
//{
//    if (isDead)
//        return;

//    enemyAudio.Play();

//    currentHealth -= amount;

//    hitParticles.transform.position = hitPoint;
//    hitParticles.Play();

//    if (currentHealth <= 0)
//    {
//        Death();
//    }
//}


//void Death()
//{
//    isDead = true;

//    capsuleCollider.isTrigger = true;

//    anim.SetTrigger("Dead");

//    enemyAudio.clip = deathClip;
//    enemyAudio.Play();
//}


//public void StartSinking()
//{
//    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
//    GetComponent<Rigidbody>().isKinematic = true;
//    isSinking = true;
//    //ScoreManager.score += scoreValue;
//    Destroy(gameObject, 2f);
//}
