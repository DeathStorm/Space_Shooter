using UnityEngine;
using System.Collections;

public class Steering : MonoBehaviour
{

    //
    // --- Component Variables
    KeyControl kControl;
    //Animator anim;

    //
    // --- Public Variables
    public float movingSpeed = 1f;



    // 
    // --- Private Variables
    KeyCode up; //= KeyCode.W;
    KeyCode down; //= KeyCode.S;
    KeyCode left; //= KeyCode.A;
    KeyCode right;// = KeyCode.D;

    KeyCode shot; // = KeyCode.Space;

    //enum DIRECTION {Up, Down, Left, Right};
    int direction = 0; // 0 - default | 1 - Up | 2 - Right | 3 - Down | 4 - Left



    //
    // ----- Methods
    void Start()
    {
        GameObject keyControlObject = GameObject.Find("GamePropertiesContainer");
        kControl = keyControlObject.GetComponent<KeyControl>();

        LoadControls();
    } // END Start

    void Update()
    {

        Move();
        // Moving

    } // END Update

    void LoadControls()
    {
        up = kControl.up;
        down = kControl.down;
        left = kControl.left;
        right = kControl.right;

        shot = kControl.shot;

    } // END LoadControls

    void Move()
    {

        float xOldPosition = this.transform.position.x;
        float yOldPosition = this.transform.position.y;

        if (Input.GetKey(up) == true)
        {

            yOldPosition += movingSpeed * Time.deltaTime;
            direction = 1;
        }
        if (Input.GetKey(right) == true)
        {

            xOldPosition += movingSpeed * Time.deltaTime;
            direction = 2;
        }

        if (Input.GetKey(down) == true)
        {

            yOldPosition -= movingSpeed * Time.deltaTime;
            direction = 3;
        }
        if (Input.GetKey(left) == true)
        {

            xOldPosition -= movingSpeed * Time.deltaTime;
            direction = 4;
        }




        if (Input.anyKey != true)
        {

            if (direction > 0)
            {


                switch (direction)
                {
                    case 1:
                      //  Debug.Log("Up");


                        //for (int i = 0; i > 50; i++)
                        //{

                        //    yOldPosition += (i / 2) * Time.deltaTime;
                        //    Vector2 fadeUp = new Vector2(xOldPosition, yOldPosition);
                        //    this.transform.position = fadeUp;
                        
                        //}

                            break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;

                }

                //direction = 0;
            }
            else
            {
                
               
            }

        }

        Vector2 newPosition = new Vector2(xOldPosition, yOldPosition);
        this.transform.position = newPosition;


        

    } // END Move

} // END Class
