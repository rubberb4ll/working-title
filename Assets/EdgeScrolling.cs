using UnityEngine;
using UnityEngine.InputSystem;

public class EdgeScrolling : MonoBehaviour
{
    private MouseHandler handler;
    private Vector2 mousePosition;
    private string mouseMode;

    private float speed = 50f;
    private float hDirection = 0f,
            vDirection = 0f;
    private float pitch, yaw;

    private bool isScrolling = false,
        wait = false;
    private float startTime = 0,
        currentTime = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        handler = new MouseHandler();

        Vector3 angles = transform.eulerAngles;
        pitch = angles.x;
        yaw = angles.y;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        mousePosition = Mouse.current.position.ReadValue();
        mouseMode = handler.CheckMouse(mousePosition);
        handler.ChangeCursor();

        if (mouseMode != "/")
        {
            if (!wait)
            {
                startTime = currentTime;
                wait = true;
            }
            else
            {
                if (currentTime - startTime >= 1f)
                {
                    isScrolling = true;
                    wait = false;
                }
            }
        }
        else
        {
            isScrolling = false;
            wait = false;
        }

        if (isScrolling)
            Scroll();
    }

    void Scroll()
    {
        switch (mouseMode)
        {
            case "w":
                hDirection = -1f;
                vDirection = 0f;
                break;
            case "e":
                hDirection = 1f;
                vDirection = 0f;
                break;
            case "s":
                hDirection = 0f;
                vDirection = 1f;
                break;
            case "n":
                hDirection = 0f;
                vDirection = -1f;
                break;

            case "sw":
                hDirection = -1f;
                vDirection = 1f;
                break;
            case "se":
                hDirection = 1f;
                vDirection = 1f;
                break;
            case "nw":
                hDirection = -1f;
                vDirection = -1f;
                break;
            case "ne":
                hDirection = 1f;
                vDirection = -1f;
                break;

            default:
                hDirection = 0f;
                vDirection = 0f;
                break;
        }

        yaw += hDirection * speed * Time.deltaTime;
        pitch += vDirection * speed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -45f, 45f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
