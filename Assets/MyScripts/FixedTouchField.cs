using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Look-area touch panel. Uses the EventSystem's per-pointer data only (no Input.touches),
/// so it works the same on a real device, the Device Simulator and the mouse.
/// Requires: a raycast-enabled UI Image on this object and an EventSystem in the scene.
/// </summary>
public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [HideInInspector] public Vector2 TouchDist;   // accumulated delta in pixels, cleared by the reader
    [HideInInspector] public int PointerId = int.MinValue;
    [HideInInspector] public bool Pressed;

    public void OnPointerDown(PointerEventData e)
    {
        if (Pressed) return;                      // ignore a second finger on this field
        Pressed = true;
        PointerId = e.pointerId;
        TouchDist = Vector2.zero;
    }

    public void OnDrag(PointerEventData e)
    {
        if (!Pressed || e.pointerId != PointerId) return;
        TouchDist += e.delta;                     // this finger's own movement only
    }

    public void OnPointerUp(PointerEventData e)
    {
        if (e.pointerId != PointerId) return;     // only our finger can release it
        Pressed = false;
        PointerId = int.MinValue;
        TouchDist = Vector2.zero;
    }

    private void OnDisable()
    {
        Pressed = false;
        PointerId = int.MinValue;
        TouchDist = Vector2.zero;
    }
}