using UnityEngine;
using System.Collections;

public class PlaceController : MonoBehaviour
{

    //
    // --- Public Variables
    public float gizmoRadius = 2f;
    

    //
    // ----- Methods
    void Start()
    {

    }

    void Update()
    {

    } // END Update


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, gizmoRadius);
    } // END OnDrawGizmos
} // END Class
