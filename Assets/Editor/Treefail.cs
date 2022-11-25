using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Treefail : EditorWindow
{
    public GameObject oldTree;
    public GameObject newTree;

    [MenuItem("Window/TreeFail")]
    public static void ShowWindow()
    {
        GetWindow<Treefail>("TreeFail");
    }

    private void OnGUI()
    {
        GUILayout.Label("This is label.", EditorStyles.boldLabel);

        if (GUILayout.Button("Change"))
        {

        }
    }

    public void changeTree()
    {
        newTree.transform.position = oldTree.transform.position;
        newTree.transform.rotation = oldTree.transform.rotation;
        Destroy(oldTree.gameObject);
    }
}
