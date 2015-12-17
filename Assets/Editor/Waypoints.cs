using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : EditorWindow {

    
    GameObject prefabs;                                      // Liste in der die Prefabs verwaltet werden
    
    int xTile = 0;              // Anzahl der Tiles in X-Richtung
    int yTile = 0;              // Anzahl der Tiles in Z-Richtung
    float offset = 0;
    int waypointCounter = 0;
   
    //
    // ~~~~~~ ShowWindow ~~~~~~
    //
    [MenuItem("TDP/Waypoints", false, 10)]
    public static void ShowWindow()
    {

        EditorWindow.GetWindow(typeof(Waypoints));

    } // END ShowWindow



    void OnGUI()
    {

        //
        // ~~~ Generate ~~~
        //
        GUILayout.Label("Generate", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate"))                   // Der Button zum Generieren
        {
            //Debug.Log("#1");
            if (prefabs != null)
            {
                //Debug.Log(xTile + " - " + zTile);
                GenerateWaypoints(xTile, yTile);
            }
        }
        
        if (GUILayout.Button("Remove"))                     // Der Button um die aktuell generierte Karte zu entfernen
        {
            GameObject removeContainer = GameObject.Find("WaypointsContainer");        // TODO - Die Bezeichnung MAP muss noch änderbar vom User werden
            DestroyImmediate(removeContainer);
            waypointCounter = 0;
        }

        GUILayout.EndHorizontal();


        //
        //~~~  BaseSettings ~~~
        //
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        prefabs = (GameObject)EditorGUILayout.ObjectField("WaypointPrefab", prefabs, typeof(GameObject), false, null);
        xTile = EditorGUILayout.IntField("Amount X-Tiles", xTile);                          // Eingabe der X-Tiles
        yTile = EditorGUILayout.IntField("Amount Y-Tiles", yTile);                          // Eingabe der Z-Tiles
        offset = EditorGUILayout.FloatField("Offset", offset);                     
        

    } // END OnGUI


    void GenerateWaypoints(int xAnzahl, int yAnzahl)
    {

        GameObject waypointHolder = new GameObject();
        waypointHolder.name = "WaypointsContainer";
        waypointHolder.transform.position = new Vector3(0f,0f,0f);

        for (int xRichtung = 0; xRichtung <= xTile; xRichtung++)
        {
            for (int yRichtung = 0; yRichtung <= yTile; yRichtung++)
            {
                
                Vector3 neuePosition = new Vector3(-2.5f +(xRichtung * offset), yRichtung * offset);
                GameObject newWaypoint = (GameObject)GameObject.Instantiate(prefabs, neuePosition, Quaternion.identity);
                newWaypoint.name = "Waypoint_" + waypointCounter;
                newWaypoint.transform.parent = waypointHolder.transform;

                waypointCounter++;
            }
        }


    } // END GenerateWaypoints



} // END Class