using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public static levelManager Instance;
    public int levelIsUnlocked;

    public Button[] button;
    // Start is called before the first frame update
    void Start()
    {
        levelIsUnlocked = PlayerPrefs.GetInt("levelisUlocked", 1);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;
        }

        for(int i = 0; i < levelIsUnlocked; i++)
        {
            button[i].interactable = true;
        }
    }

    public void LoadLevel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
