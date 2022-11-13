using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorStarterTexture;
    [SerializeField] private Texture2D cursorClickTexture;
    //[SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cursorHotspot = new Vector2(cursorHotspot.x / 2, cursorHotspot.y / 2);
        
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorClickTexture, cursorHotspot, CursorMode.Auto);
            Debug.Log(Input.GetMouseButtonDown(0));
        }
        else
        {
            Cursor.SetCursor(cursorStarterTexture, cursorHotspot, CursorMode.Auto);
        }
    }
}
