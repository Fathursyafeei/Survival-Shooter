using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Cari game object dengan tag player.

        //Mendapatkan Reference component
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        // Memindahkan posisi player
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        // Hentikan moving.
        else
        {
            nav.enabled = false;
        }
    }
}
