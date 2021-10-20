using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    EnemyFactory factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
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
        int spawnEnemy = Random.Range(0, 3);

        // Menduplikasi enemy
        Factory.FactoryMethod(spawnEnemy);
        
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