using UnityEngine;
using System.Collections;

public class TestColliderDS : MonoBehaviour {

    Steering steering;

	// Use this for initialization
	void Start () 
    {
        steering = gameObject.GetComponent<Steering>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Obstacle")
        {
            steering.enabled = false;
            Debug.Log("BADUMDISCH EXPLOSIONEN");
        }
    }
}
