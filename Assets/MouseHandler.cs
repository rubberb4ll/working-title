using Unity.VisualScripting;
using UnityEngine;

public class MouseHandler
{
    private Texture2D texture;
    private Vector2 hotspot = new Vector2(8, 4);

    private Vector2 hBound, vBound;
    private string mouseMode = "/";

    public MouseHandler()
    {
        texture = new Texture2D(32, 32);
        texture = Resources.Load<Texture2D>("Cursor/cursor_none");

        int h = Screen.width / 5,
            v = Screen.height / 3;
        hBound = new Vector2(h, Screen.width - h);
        vBound = new Vector2(v, Screen.height - v);
    }

    public string CheckMouse(Vector2 mousePosition)
    {
        mouseMode = "/";

        if (mousePosition.x < hBound.x)
            mouseMode = "w";
        if (mousePosition.x > hBound.y)
            mouseMode = "e";
        if (mousePosition.y < vBound.x)
            mouseMode = "s";
        if (mousePosition.y > vBound.y)
            mouseMode = "n";

        if (mousePosition.y < vBound.x && mousePosition.x < hBound.x)
            mouseMode = "sw";
        if (mousePosition.y < vBound.x && mousePosition.x > hBound.y)
            mouseMode = "se";
        if (mousePosition.y > vBound.y && mousePosition.x < hBound.x)
            mouseMode = "nw";
        if (mousePosition.y > vBound.y && mousePosition.x > hBound.y)
            mouseMode = "ne";

        return mouseMode;
    }

    public void ChangeCursor()
    {
        switch (mouseMode)
        {
            case "w":
                texture = Resources.Load<Texture2D>("Cursor/arrow_w");
                break;
            case "e":
                texture = Resources.Load<Texture2D>("Cursor/arrow_e");
                break;
            case "s":
                texture = Resources.Load<Texture2D>("Cursor/arrow_s");
                break;
            case "n":
                texture = Resources.Load<Texture2D>("Cursor/arrow_n");
                break;

            case "sw":
                texture = Resources.Load<Texture2D>("Cursor/arrow_sw");
                break;
            case "se":
                texture = Resources.Load<Texture2D>("Cursor/arrow_se");
                break;
            case "nw":
                texture = Resources.Load<Texture2D>("Cursor/arrow_nw");
                break;
            case "ne":
                texture = Resources.Load<Texture2D>("Cursor/arrow_ne");
                break;

            default:
                texture = Resources.Load<Texture2D>("Cursor/cursor_none");
                break;
        }

        Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
    }
}