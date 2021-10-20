using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectDisplayTime = 0.2f;

    private void Awake()
    {
        // Get Mask
        shootableMask = LayerMask.GetMask("Shootable");

        //Mendapatkan Reference Component
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }
        if(timer >= timeBetweenBullets * effectDisplayTime)
        {
            DisableEffects();
        }
    }

    private void Shoot()
    {
        timer = 0f;

        // Play Audio
        gunAudio.Play();

        //enable light
        gunLight.enabled = true;

        // Play gun particle
        gunParticles.Stop();
        gunParticles.Play();

        //Enable Line renderer dan set first position
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        //Set posisi ray shoot dan direction
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Lakukan raycast jika mendeteksi  enemy hit apapun
        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Lakukan raycast hit component enemyHealth
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if(enemyHealth != null)
            {
                // jalankan TakeDamage
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }

            // Set line end position ke hit position
            gunLine.SetPosition(1, shootHit.point); 
        }
        else
        {
            // Set line end position ke range from barrel
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    private void DisableEffects()
    {
        // disable line renderer
        gunLine.enabled = false;

        // disable Light
        gunLight.enabled = false;
    }



}

//public int damagePerShot = 20;                  
//public float timeBetweenBullets = 0.15f;        
//public float range = 100f;                      

//float timer;                                    
//Ray shootRay;                                   
//RaycastHit shootHit;                            
//int shootableMask;                             
//ParticleSystem gunParticles;                    
//LineRenderer gunLine;                           
//AudioSource gunAudio;                           
//Light gunLight;                                 
//float effectsDisplayTime = 0.2f;                

//void Awake()
//{
//    shootableMask = LayerMask.GetMask("Shootable");
//    gunParticles = GetComponent<ParticleSystem>();
//    gunLine = GetComponent<LineRenderer>();
//    gunAudio = GetComponent<AudioSource>();
//    gunLight = GetComponent<Light>();
//}

//void Update()
//{
//    timer += Time.deltaTime;

//    if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
//    {
//        Shoot();
//    }

//    if (timer >= timeBetweenBullets * effectsDisplayTime)
//    {
//        DisableEffects();
//    }
//}

//public void DisableEffects()
//{
//    gunLine.enabled = false;
//    gunLight.enabled = false;
//}

//void Shoot()
//{
//    timer = 0f;

//    gunAudio.Play();

//    gunLight.enabled = true;

//    gunParticles.Stop();
//    gunParticles.Play();

//    gunLine.enabled = true;
//    gunLine.SetPosition(0, transform.position);

//    shootRay.origin = transform.position;
//    shootRay.direction = transform.forward;

//    if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
//    {
//        EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

//        if (enemyHealth != null)
//        {
//            enemyHealth.TakeDamage(damagePerShot, shootHit.point);
//        }

//        gunLine.SetPosition(1, shootHit.point);
//    }
//    else
//    {
//        gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
//    }
//}