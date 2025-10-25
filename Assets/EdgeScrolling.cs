using UnityEngine;
using UnityEngine.InputSystem;

public class EdgeScrolling : MonoBehaviour
{
    private Vector2 hBound, vBound;
    private Vector2 mousePosition;

    private float speed = 50f;
    private float hRotation, vRotation;

    private float currentTime = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        int h = Screen.width / 5,
            v = Screen.height / 3;
        hBound = new Vector2(h, Screen.width - h);
        vBound = new Vector2(v, Screen.height - v);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        Debug.Log(currentTime);
        
        mousePosition = Mouse.current.position.ReadValue();

        if (mousePosition.x < hBound.x) // camera w
            hRotation = -1f;
        else if (mousePosition.x > hBound.y) // camera e
            hRotation = 1f;
        else hRotation = 0f;
        if (mousePosition.y < vBound.x) // camera s
            vRotation = -1f;
        else if (mousePosition.y > vBound.y) // camera n
            vRotation = 1f;
        else vRotation = 0f;

        transform.Rotate(vRotation * speed * Time.deltaTime,
            hRotation * speed * Time.deltaTime,
            0f,
            Space.Self);
    }
}
