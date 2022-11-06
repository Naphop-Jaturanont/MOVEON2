using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public static levelManager Instance;
    public int levelIsUnlocked;
    public int continueScene;
    public int openFirst = 0;
    public Button continueBtn;

    // Start is called before the first frame update
    void Start()
    {
        levelIsUnlocked = PlayerPrefs.GetInt("levelisUlocked", levelIsUnlocked);

        
    }

    private void Awake()
    {
        Debug.Log(openFirst);
        if (openFirst == 0)
        {
            continueBtn.interactable = false;
            PlayerPrefs.SetInt("continueScene", 0);
            openFirst = 1;
        }
        Debug.Log(PlayerPrefs.GetInt("continueScene", continueScene));
        if (PlayerPrefs.GetInt("continueScene", continueScene) > 1)
        {
            continueBtn.interactable = true;
        }
    }
    public void NewGame()
    {
        LoadLevel("Stage0");
    }

    public void ContinueGame()
    {
        int goScene = PlayerPrefs.GetInt("continueScene", continueScene);
        LoadLevelScene(goScene);
    }

    public void LoadLevel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void LoadLevelScene(int indexScene)
    {
        SceneManager.LoadSceneAsync(indexScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
