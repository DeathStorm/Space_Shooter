using UnityEngine;
using System.Collections;

public class PlayershipProperties : MonoBehaviour {

    //
    // --- Component Variables
    GameObject stageContainer;
    StageProperties stageProp;
    AudioSource soundSource;

    //
    // --- Public Variables
    public AudioClip deadSound;
    //
    // --- Private Variables




	//
    // ----- Methods
	void Start () 
    {
        stageContainer = GameObject.Find("StagePropertiesContainer");
        stageProp = stageContainer.GetComponent<StageProperties>();
        soundSource = this.GetComponent<AudioSource>();
	} // END Start
	
	void Update () 
    {

        if (stageProp.playerHealth <= 0)
        {
            soundSource.PlayOneShot(deadSound);
            SetPlayerDead();
        }


	} // END Update

    void SetDamage(int damage)
    {
        stageProp.playerHealth -= damage;
    } // END SetDamage

    void SetPlayerDead()
    {
        
        GameObject.Destroy(this.gameObject);
    
    } // END SetPlayerDead


} // END Class
