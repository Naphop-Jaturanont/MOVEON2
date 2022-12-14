using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelPass : MonoBehaviour
{
    public stage1 Stage1;
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("levelisUlocked"));
        UnlockWay(SceneManager.GetActiveScene().buildIndex-2);
        Stage1.SaveToFile();
    }
    private void Awake()
    {
        UnlockWay(SceneManager.GetActiveScene().buildIndex - 2);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("continueScene", currentScene);
    }
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        

        if (currentLevel >= PlayerPrefs.GetInt("levelisUlocked"))
        {
            PlayerPrefs.SetInt("levelisUlocked", currentLevel + 1);
        }

        
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex - 2 >= 0)
        {
            if (Stage1.indexLightNovel[SceneManager.GetActiveScene().buildIndex - 2] != true)
            {
                UnlockWay(SceneManager.GetActiveScene().buildIndex - 2);
            }
        }
        
    }

    public void UnlockWay(int index)
    {
        if(index >= 0)
        {
            Stage1.indexLightNovel[index] = true;
        }
        
    }
}
