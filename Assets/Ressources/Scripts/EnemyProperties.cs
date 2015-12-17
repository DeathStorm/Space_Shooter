using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour {

    //
    // --- Component Variables
    GameObject weaponPosition;
    AudioSource soundSource;
    AmmoProperties ammoProp;
    GameObject ammoHandler;
    Rigidbody2D rBody;
    Animator anim;
    //
    // --- Public Variables
    public GameObject ammo;
    public AudioClip ammoShotSound;
    public AudioClip deadSound;
    public int health = 100;
    public int shield = 100;
    public float ammoSpeed = 1.1f;
    public float shotFrequencyMin = 1.5f;
    public float shotFrequencyMax = 3.0f;
    public float enemySpeed = 1f;
    public float directionCounterMin = 1f;
    public float directionCounterMax = 3f;
    //
    // --- Private Variables
    float nextAttack;
    float nextAttackIn = 3f;
    int direction = 0;
    float directionCounter = 3f;
    float directionCounterSet;
    bool started = false;

	//
    // ----- Methods
	void Start () 
    {
        weaponPosition = this.transform.FindChild("WeaponPosition").gameObject;
        soundSource = this.GetComponent<AudioSource>();
        ammoHandler = GameObject.Find("AmmoHandler");
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        SetDirectionCounterTime();
        nextAttack = nextAttackIn;
	} // END Start
	
	
	void Update ()
    {

        if (started == false)
        {
            anim.Play("Enemy_FlyIn");
            //started = true;
        }

        if (health <= 0)
        {
            soundSource.PlayOneShot(deadSound);
            DestroyThisEnemy();
        }

        if (nextAttack <= nextAttackIn)
        {
            nextAttack -= 1 * Time.deltaTime;

            if (nextAttack <= 0)
            {
                Attack();

                float rnd = Random.Range(shotFrequencyMin, shotFrequencyMax);
                nextAttackIn = rnd;
                nextAttack = nextAttackIn;
            }
        }


        if (directionCounter <= directionCounterSet)
        {
            directionCounter -= 1 * Time.deltaTime;
            
            if (directionCounter <= 0)
            {
                int rndDirection = Random.Range(-1, 2);
                SetDirection(rndDirection);

                SetDirectionCounterTime();
            }
        }




	} // END Update

    void SetStartedTrue(string state)
    {

        if (state == "true")
        {
            started = true;
            anim.Play("Idle");
        }

    } // END SetStartedTrue


    void SetDamage(int damage)
    {

        health -= damage;
    
    } // END GetDamage

    void DestroyThisEnemy()
    {
        
        GameObject.Destroy(this.gameObject);

    } // END DestroyThisEnemy

    void Attack()
    {
        

        soundSource.PlayOneShot(ammoShotSound);

        float yAlt = weaponPosition.transform.position.y;
        Vector3 newShotPosition = new Vector3(weaponPosition.transform.position.x, yAlt, weaponPosition.transform.position.z);
        GameObject newShotObject = (GameObject)GameObject.Instantiate(ammo, newShotPosition, Quaternion.identity);
        ammoProp = newShotObject.GetComponent<AmmoProperties>();
        ammoProp.target = "Player";

        newShotObject.transform.parent = ammoHandler.transform;

        Rigidbody2D newShotRigidBody = newShotObject.GetComponent<Rigidbody2D>();
        newShotRigidBody.velocity = new Vector3(0f, -ammoSpeed, 0);

    } // END Attack

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "DeadZone")
        {
            DestroyThisEnemy();
        }

        if (collider.tag == "Obstacle")
        {
            switch (direction)
            { 
                case -1:
                    SetDirection(1);
                    break;
                case 0:
                    break;
                case 1:
                    SetDirection(-1);
                    break;
            
            }
            
            //if (direction == -1) { SetDirection(1); }
            //if (direction == 1) { SetDirection(-1); }
            ////Debug.Log(collider.tag);
        }


    } // END OnTriggerEnter2D

    void SetDirection(int rndDirection)
    {

        switch (rndDirection)
        {
            case -1:
                
                rBody.velocity = new Vector3(-enemySpeed, -enemySpeed, 0f);

                break;
            case 0:
                rBody.velocity = new Vector3(0f, -enemySpeed, 0f);
                break;
            case 1:
                rBody.velocity = new Vector3(enemySpeed, -enemySpeed, 0f);

                break;       
        }

        direction = rndDirection;


    } // END SetDirection

    void SetDirectionCounterTime()
    {

        float rndDirectionTime = Random.Range(directionCounterMin, (directionCounterMax +1f));

        directionCounterSet = rndDirectionTime;
        directionCounter = rndDirectionTime;

    } // END SetDirectionCounterTime

} // END Class
