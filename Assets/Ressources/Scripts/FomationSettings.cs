using UnityEngine;
using System.Collections;

public class FomationSettings : MonoBehaviour {

	
    //
    // --- Public Variables
    public float gizmoWith = 2f;
    public float gizmoHeight = 2f;


    //
    // ----- Methods
    void Start () 
    {
	
	}
	
	void Update ()
    {
	
	} // END Update


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(gizmoWith, gizmoHeight));
    } // END OnDrawGizmos
} // END Class
