using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private void Start()
    {
        // Mengeksekusi fungsi Spawn setiap beberapa detik sesuai nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Jika player telah mati maka tidak membuat enemy baru.
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // Get nilai Random
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Menduplikasi enemy
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}


//public PlayerHealth playerHealth;
//public GameObject enemy;
//public float spawnTime = 3f;
//public Transform[] spawnPoints;


//void Start ()
//{
//    InvokeRepeating("Spawn", spawnTime, spawnTime);
//}


//void Spawn ()
//{
//    if (playerHealth.currentHealth <= 0f)
//    {
//        return;
//    }

//    int spawnPointIndex = Random.Range (0, spawnPoints.Length);
//    Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

//}