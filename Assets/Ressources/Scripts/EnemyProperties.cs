using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour {

    //
    // --- Component Variables
    GameObject weaponPosition;
    AudioSource soundSource;
    AmmoProperties ammoProp;
    //
    // --- Public Variables
    public GameObject ammo;
    public AudioClip ammoShotSound;
    public AudioClip deadSound;
    public int health = 100;
    public int shield = 100;
    public float ammoSpeed = 1.1f;
    public float shotFrequency = 4f;

    //
    // --- Private Variables
    float nextAttack;








	//
    // ----- Methods
	void Start () 
    {
        weaponPosition = this.transform.FindChild("WeaponPosition").gameObject;
        soundSource = this.GetComponent<AudioSource>();
        nextAttack = shotFrequency;
	} // END Start
	
	
	void Update ()
    {

        if (health <= 0)
        {
            soundSource.PlayOneShot(deadSound);
            DestroyThisEnemy();
        }

        if (nextAttack <= shotFrequency)
        {
            nextAttack -= 1 * Time.deltaTime;

            if (nextAttack <= 0)
            {
                Attack();
                nextAttack = shotFrequency;
            }
        }





        // Shield beschädigen
        //* Leben abziehen
        // Zurückschiessen
        //* Kaputt gehen

	} // END Update

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
        //Debug.Log(shotStartObject.transform.position);

        Rigidbody2D newShotRigidBody = newShotObject.GetComponent<Rigidbody2D>();
        newShotRigidBody.velocity = new Vector3(0f, -ammoSpeed, 0);

    } // END Attack
} // END Class
