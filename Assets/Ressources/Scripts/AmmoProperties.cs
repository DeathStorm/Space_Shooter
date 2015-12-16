using UnityEngine;
using System.Collections;

public class AmmoProperties : MonoBehaviour {

    // 
    // --- Component Variables
    Animator anim;
    
    //
    // --- Public Variables
    public AnimationClip flyingAnim;
    public float flyingSpeed;
    public float flyingDistance;
    public int damage;

    //
    // --- Private Variables
    bool isFlying = false;
    float flyDistance;              // Zurückgelegte Distanz

	//
    // ----- Methods
	void Start () 
    {
        anim = this.GetComponent<Animator>();


        isFlying = true;
	} // END Start
	
	// Update is called once per frame
	void Update () 
    {

        if (isFlying == true)
        {
            anim.Play(flyingAnim.name);
        }

        if (flyDistance < flyingDistance)
        {

            flyDistance += (1 * Time.deltaTime);
        }
        else
        {
            DestroyThisAmmo();
        }




	} // END Update

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {

            //  DestroyThisInstance();
            coll.gameObject.SendMessage("SetDamage", damage, SendMessageOptions.DontRequireReceiver);
            DestroyThisAmmo();
        }
    } // END OnTriggerEnter2D

    void DestroyThisAmmo()
    {
        GameObject.Destroy(this.gameObject);
    } // END DestroyThisAmmo



} // END Class
