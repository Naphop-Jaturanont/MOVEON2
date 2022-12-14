using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public stage1 Stage1;

    //BUTTON
    public Button[] buttonChapter1 = null ;
    public Button[] buttonChapter2 = null ;
    public Button[] buttonChapter3 = null ;

    public GameObject ChapterSelectUI;

    public Image[] sprite;
    public Sprite[] spriteInter;
    public Sprite spriteDefault;
    private void Awake()
    {
        /*if (_instance != null) Destroy(this);
        DontDestroyOnLoad(this);*/
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Stage1.indexLightNovel[0] = false;
            Stage1.SaveToFile();
        }
    }

    public void OpenChapterUI()
    {
        ChapterSelectUI.SetActive(true);
        Stage1.LoadDataFromFile();
        Debug.Log(Stage1.indexLightNovel[0]);
        for (int i = 0; i <= Stage1.indexLightNovel.Length - 1; i++)
        {
            if (Stage1.indexLightNovel[i] == true && buttonChapter1[i] != null)
            {
                buttonChapter1[i].interactable = true;
                sprite[i].sprite = spriteInter[i];
            }
            if (Stage1.indexLightNovel[i] == false && buttonChapter1[i] != null)
            {
                buttonChapter1[i].interactable = false;
                sprite[i].sprite = spriteDefault;
            }
        }
    }

    
}
