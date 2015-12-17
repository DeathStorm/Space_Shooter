using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathfindingTryout : MonoBehaviour {

	
    //
    // --- Component Variables
    Rigidbody2D rBody;
    
    //
    // --- Public Variables
    public Transform playerObject;
    public List<Transform> waypoints;
    public float speed = 2f;
    public float rotationSpeed = 2f;

    //
    // --- Private Variables
    int waypointsCount;
    int currentWaypoint = 0;
    bool playerSelected = false;

    //
    // ----- Methods
    void Start () 
    {
        rBody = this.GetComponent<Rigidbody2D>();
        waypointsCount = waypoints.Count;
	} // END Start
	
	void Update () 
    {
        if (currentWaypoint == waypointsCount)
        {
            rBody.velocity = Vector3.zero;

            if (playerSelected == false)
            {
                RotateTo(playerObject.position);
               // playerSelected = true;
            }

        }
        else 
        {
            RotateTo(waypoints[currentWaypoint].position);
            GoToNextWaypoint();
        }
        
	} // END Update

    void RotateTo(Vector3 targetPosition)
    {
        Vector3 relativPosition;
        Vector3 actPosition = new Vector3(transform.position.x, transform.position.y);
        relativPosition = targetPosition - actPosition;




        relativPosition.Normalize();

        float rotZ = Mathf.Atan2(relativPosition.y, relativPosition.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0,0,rotZ -90);



    } // END RotateTo


    void GoToNextWaypoint()
    {

        Vector3 targetPosition = waypoints[currentWaypoint].position;
        Vector3 velocity;
        Vector3 moveDirection = transform.TransformDirection(Vector2.up);
        Vector3 delta = targetPosition - transform.position;

        velocity = moveDirection.normalized * speed * Time.deltaTime;
        //Debug.Log("1");
        if (delta.magnitude > 0.1)
        {
            //Debug.Log("2");
        }
        else
        {
            //Debug.Log("3");
            if (currentWaypoint < waypointsCount)
            {

                //Debug.Log("4"); 
                currentWaypoint++;
            }
            else { }
        }

        rBody.velocity = velocity;
    
    } // END GoToNextWaypoint



} // END Class
