using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage", menuName = "Stage")]
public class stage1 : ScriptableObject
{
    public int scoreOfChoice;
    public bool passStage;
    public bool[] indexLightNovel;

    private const string FILENAME = "sss.dat";
    public void SaveToFile()
    {
        var filePath = Path.Combine(Application.persistentDataPath, FILENAME);

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        var json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }

    public void LoadDataFromFile()
    {
        var filePath = Path.Combine(Application.persistentDataPath, FILENAME);

        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"File \"{filePath}\" not found!", this);
            return;
        }

        var json = File.ReadAllText(filePath);
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
