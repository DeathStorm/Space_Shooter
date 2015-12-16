using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class LevelGenRandom : MonoBehaviour
{


    public List<GameObject> wallPrefabs;
    public int startLevelDepth = 5;
    public float depthOffSet = 0.32f;
    public float gameWidth = 6.0f;


    private GameObject levelHolder;

    private float lastYPosition;

    //private int lastTileNumber = 0;
    //private int lastTileNumberDestroyed = 99999;

    //private float lastDestoyedYPosition = 99999;

    // Use this for initialization
    void Awake()
    {

        GenerateInitialMap();
    }

    public void GenerateInitialMap()
    {
        if (levelHolder == null) { levelHolder = GameObject.Find("Level Holder"); }

        if (levelHolder == null)
        {
            levelHolder = new GameObject();
            levelHolder.name = "Level Holder";
            //levelHolder.AddComponent<Transform>();
            levelHolder.transform.position = new Vector3(0, 0, 0);

        }
        else
        {
            foreach (Transform childtransform in levelHolder.transform)
            {
                if (Application.isEditor)
                { DestroyImmediate(childtransform.gameObject); }
                else
                { Destroy(childtransform.gameObject); }
            }
        }

        for (int depth = -startLevelDepth; depth <= startLevelDepth; depth++)
        {
            GenerateNewTile(depth * depthOffSet);
        }
    }

    void GenerateNewTile(float yPosition)
    {
        GameObject wallPrefab;
        Tile tile;

        wallPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Count)];
        GameObject wallObjectRight = (GameObject)GameObject.Instantiate(wallPrefab, new Vector3(gameWidth / 2, yPosition, 0), wallPrefab.transform.rotation);
        tile = wallObjectRight.GetComponent<Tile>();
        tile.isTileDestoryable = true;

        wallObjectRight.transform.SetParent(levelHolder.transform);

        wallPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Count)];
        GameObject wallObjectLeft = (GameObject)GameObject.Instantiate(wallPrefab, new Vector3((gameWidth / 2) * -1, yPosition, 0), wallPrefab.transform.rotation);
        wallObjectLeft.transform.Rotate(new Vector3(0, 0, 180));
        wallObjectLeft.transform.SetParent(wallObjectRight.transform);

        //lastTileNumber++;
        lastYPosition = yPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.tag == "Obstacle")
        {
            Tile tile = collisionObject.GetComponent<Tile>();

            if (tile.isTileDestoryable || collisionObject.transform.childCount>0)
            {
                GenerateNewTile(lastYPosition);// + depthOffSet);
                //lastTileNumberDestroyed = tile.tileNumber;
                tile = null;
                Destroy(collisionObject);
            }


        }
    }
}
