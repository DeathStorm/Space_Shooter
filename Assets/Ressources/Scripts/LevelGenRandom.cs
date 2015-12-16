using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class LevelGenRandom : MonoBehaviour {


    public List<GameObject> wallPrefabs;
    public int startLevelDepth = 6;
    public float depthOffSet = 0.32f;
    public float gameWidth = 6.0f;

    private GameObject levelHolder;

	// Use this for initialization
	void Start () 
    {
 
	
	}

    public void GenerateInitialMap()
    {
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

        for (int depth = 0; depth <= startLevelDepth; depth++)
        {
            GameObject wallPrefab;

            wallPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Count)];
            GameObject wallObjectRight = (GameObject)GameObject.Instantiate(wallPrefab, new Vector3(gameWidth / 2, depth * depthOffSet, 0), wallPrefab.transform.rotation);
            wallObjectRight.transform.SetParent(levelHolder.transform);

            wallPrefab = wallPrefabs[Random.Range(0, wallPrefabs.Count)];
            GameObject wallObjectLeft = (GameObject)GameObject.Instantiate(wallPrefab, new Vector3((gameWidth / 2)*-1, depth * depthOffSet, 0), wallPrefab.transform.rotation);
            wallObjectLeft.transform.Rotate(new Vector3(0,0,180));
            wallObjectLeft.transform.SetParent(wallObjectRight.transform);


        }
    }

    // Update is called once per frame
    void Update()
    {
	
	}
}
