using UnityEngine;
using System.Collections;

public class EnemySpawnPointProperties : MonoBehaviour {

    //
    // --- Component Variables



    //
    // --- Public Variables
    public GameObject[] enemyPrefabs;
    public int enemyToSpawnAmount = 10;
    public float enemySpawnFrequency = 5f;

    //
    // --- Private Variables
    int enemyToSpawnCount = 0;
    float enemySpawnTimer;
    int enemyPrefabsAmount;

	//
    // ----- Methods
	void Start () 
    {


        enemySpawnTimer = enemySpawnFrequency;
        enemyPrefabsAmount = enemyPrefabs.Length;
	} // END Start
	
	void Update () 
    {

        if (enemySpawnTimer <= enemySpawnFrequency)
        {
            if (enemySpawnTimer > 0f)
            {
                enemySpawnTimer -= 1 * Time.deltaTime;

            }
            else
            {
                EnemySpawn();

                enemySpawnTimer = enemySpawnFrequency;
            }
        
        }


	} // END Update


    void EnemySpawn()
    {

        int rnd = Random.Range(0, enemyPrefabsAmount);

        GameObject newEnemy = (GameObject)GameObject.Instantiate(enemyPrefabs[rnd], this.transform.position ,  new Quaternion(0f,0f,180f,0f));
        newEnemy.transform.parent = this.gameObject.transform;

        EnemyProperties enemyProp = newEnemy.GetComponent<EnemyProperties>();

        Rigidbody2D rBody = newEnemy.GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector3(0f, -enemyProp.enemySpeed, 0);

    
    } // END EnemySpawn

} // END Class
