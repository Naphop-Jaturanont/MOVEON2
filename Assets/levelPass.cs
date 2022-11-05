using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelPass : MonoBehaviour
{
    public stage1 Stage1;
    private void Awake()
    {
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

    public void UnlockWay(int index)
    {
        Stage1.indexLightNovel[index] = true;
    }
}
