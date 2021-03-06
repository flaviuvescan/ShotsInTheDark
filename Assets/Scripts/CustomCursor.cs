﻿using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour {

    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
}
