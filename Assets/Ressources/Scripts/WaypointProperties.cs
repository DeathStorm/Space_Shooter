using UnityEngine;
using System.Collections;

public class WaypointProperties : MonoBehaviour {

    //
    // --- Public Variables
    public float gizmoRadius = 0.2f;
    public Color gizmoColor = Color.cyan;



    //
    // ----- Methods
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
        

    } // END OnDrawGizmos

} // END Class
