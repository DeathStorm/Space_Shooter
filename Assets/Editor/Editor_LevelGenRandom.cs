using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LevelGenRandom))]
public class Editor_LevelGenRandom : Editor {

    public override void OnInspectorGUI()
    {
       


        if (GUILayout.Button("Regenerate Map"))
        {
            LevelGenRandom levelGenRandom = (LevelGenRandom)target;
            levelGenRandom.GenerateInitialMap();
        }

        base.OnInspectorGUI();
    }
}
