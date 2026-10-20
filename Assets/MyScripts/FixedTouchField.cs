using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;

    [HideInInspector]
    public bool Pressed;

    private Vector2 pointerOld;
    private int pointerId = -1;

    void Update()
    {
        if (Pressed)
        {
            // Track the movement difference since the last frame
            if (pointerId >= 0 && pointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[pointerId].position - pointerOld;
                pointerOld = Input.touches[pointerId].position;
            }
            else
            {
                // Fallback for testing inside the Unity Editor with a mouse
                TouchDist = (Vector2)Input.mousePosition - pointerOld;
                pointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = Vector2.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        pointerId = eventData.pointerId;
        pointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        pointerId = -1;
    }
}
