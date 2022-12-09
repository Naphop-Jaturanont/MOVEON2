using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogOnVDO : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    [TextArea]
    public string[] lines;
    public float textSpeed;

    [HideInInspector]public int index;
    public bool maxLine;
    public bool ingame = false;
    private QuickTimeEvent quickTime;
    private PauseGame pauseGame;

    [SerializeField]private bool check = false;

    private IEnumerator enumerator;
    // Start is called before the first frame update
    private void Awake()
    {
        pauseGame = GameObject.Find("CanvasPause").GetComponent<PauseGame>();
    }
    void Start()
    {
        textMeshPro.text = string.Empty;
        quickTime = gameObject.GetComponentInParent<QuickTimeEvent>();
        startDialogue();
    }   
    public void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    private void Update()
    {
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {        
        if(pauseGame.isPause == false)
        {
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                if (textMeshPro.text == lines[index])
                {
                    NextLine();
                }
                else 
                {
                    StopAllCoroutines();
                    textMeshPro.text = lines[index];

                }
            }
            if (textMeshPro.text == lines[index])
            {
                maxLine = true;
            }
            else
            {
                maxLine = false;
            }
        }
        
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textMeshPro.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if(ingame == true)
            {
                movement Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
                Movement.enable = false;
            }
        }
    }

    public void ResetDialog()
    {
        maxLine = false;
        textMeshPro.text = string.Empty;
        index = 0;
        check = false;
    }
}
