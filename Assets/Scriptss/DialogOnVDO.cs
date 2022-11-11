using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogOnVDO : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] lines;
    public float textSpeed;

    private int index;
    private QuickTimeEvent quickTime;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = string.Empty;
        quickTime = gameObject.GetComponentInParent<QuickTimeEvent>();
        startDialogue();
    }
    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(quickTime.key1))
        {
            if(textMeshPro.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshPro.text = lines[index];
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
        }
    }
}
