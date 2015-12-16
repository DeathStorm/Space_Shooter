using UnityEngine;
using System.Collections;

public class LevelMove : MonoBehaviour
{

    GameObject levelHolder;
    public float levelSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (levelHolder == null) { levelHolder = GameObject.Find("Level Holder"); }

        if (levelHolder != null)
        {
            levelHolder.transform.position += new Vector3(0, -Time.deltaTime, 0);
        }
    }
}
