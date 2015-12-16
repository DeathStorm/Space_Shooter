using UnityEngine;
using System.Collections;

public class Steering : MonoBehaviour
{

    //
    // --- Component Variables
    KeyControl kControl;
    GameObject weaponPosition;
    AudioSource soundSource;
    AmmoProperties ammoProps;

    //
    // --- Public Variables
    public GameObject ammo1;
    public AudioClip ammo1Shot;
    public AudioClip deadSound;
    public float movingSpeed = 1f;
    public float fadeDistance = 1f;
    public float ammoSpeed = 1.5f;

    // 
    // --- Private Variables
    KeyCode up; //= KeyCode.W;
    KeyCode down; //= KeyCode.S;
    KeyCode left; //= KeyCode.A;
    KeyCode right;// = KeyCode.D;

    KeyCode shot; // = KeyCode.Space;

    float fade;


    //enum DIRECTION {Up, Down, Left, Right};
    int direction = 0; // 0 - default | 1 - Up | 2 - Right | 3 - Down | 4 - Left



    //
    // ----- Methods
    void Start()
    {
        GameObject keyControlObject = GameObject.Find("GamePropertiesContainer");
        kControl = keyControlObject.GetComponent<KeyControl>();
        weaponPosition = this.gameObject.transform.FindChild("WeaponPosition").gameObject;
        soundSource = this.GetComponent<AudioSource>();

        LoadControls();
        fade = fadeDistance;
    } // END Start

    void Update()
    {

        Move();
        MoveFade();
        Attack();
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
            fade = fadeDistance;
        }
        if (Input.GetKey(right) == true)
        {

            xOldPosition += movingSpeed * Time.deltaTime;
            direction = 2;
            fade = fadeDistance;
        }

        if (Input.GetKey(down) == true)
        {

            yOldPosition -= movingSpeed * Time.deltaTime;
            direction = 3;
            fade = fadeDistance;
        }
        if (Input.GetKey(left) == true)
        {

            xOldPosition -= movingSpeed * Time.deltaTime;
            direction = 4;
            fade = fadeDistance;
        }

        Vector2 newPosition = new Vector2(xOldPosition, yOldPosition);
        this.transform.position = newPosition;
 

    } // END Move

    void MoveFade()
    {

        float xOldPosition = this.transform.position.x;
        float yOldPosition = this.transform.position.y;

        if (Input.anyKey != true && fade > 0f)
        {

            if (direction > 0)
            {

                switch (direction)
                {
                    case 1:
                            yOldPosition += 1 * Time.deltaTime;
                            Vector2 fadeUp = new Vector2(xOldPosition, yOldPosition);
                            this.transform.position = fadeUp;

                            fade -= 1 * Time.deltaTime;
                            break;
                    case 2:
                            xOldPosition += 1 * Time.deltaTime;
                            Vector2 fadeRight = new Vector2(xOldPosition, yOldPosition);
                            this.transform.position = fadeRight;

                            fade -= 1 * Time.deltaTime;
                            break;
                    case 3:
                            yOldPosition -= 1 * Time.deltaTime;
                            Vector2 fadeDown = new Vector2(xOldPosition, yOldPosition);
                            this.transform.position = fadeDown;

                            fade -= 1 * Time.deltaTime;
                            break;
                    case 4:
                            xOldPosition -= 1 * Time.deltaTime;
                            Vector2 fadeLeft = new Vector2(xOldPosition, yOldPosition);
                            this.transform.position = fadeLeft;

                            fade -= 1 * Time.deltaTime;
                            break;

                }

                if (fade <= 0)
                {
                    direction = 0;
                }
            }
            else
            {

            }
        }
      
    } // END MoveFade

    void Attack()
    {
        if(Input.GetKeyDown(shot))
        {
            soundSource.PlayOneShot(ammo1Shot);
            
            float yAlt = weaponPosition.transform.position.y;
            Vector3 newPowPosition = new Vector3(weaponPosition.transform.position.x, yAlt, weaponPosition.transform.position.z);
            GameObject newShot = (GameObject)GameObject.Instantiate(ammo1, newPowPosition, Quaternion.identity);
            ammoProps = newShot.GetComponent<AmmoProperties>();

            ammoProps.target = "Enemy";
            //Debug.Log(shotStartObject.transform.position);

            Rigidbody2D newPowRigid = newShot.GetComponent<Rigidbody2D>();
            newPowRigid.velocity = new Vector3(0f, ammoSpeed, 0);

        }
        
    
    
    } // END Attack


} // END Class
