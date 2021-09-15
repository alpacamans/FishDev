using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [SerializeField] private RectTransform rect_Backgorund;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;
    private Vector3 movePosition;

    public bool isTouch = false;

    public Vector2 value;

    // Start is called before the first frame update
    void Start()
    {
        radius = rect_Backgorund.rect.width*0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        value = eventData.position - (Vector2)rect_Backgorund.position;

        value = Vector2.ClampMagnitude(value, radius);

        rect_Joystick.localPosition = value;

        value = value.normalized;

        
        //Debug.Log("x" + value.x + "y" + value.y);
        //Debug.Log("up=" + up + "down=" + down + "left=" + left + "right=" + right);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        isTouch = false;
        rect_Joystick.localPosition = Vector3.zero;
    }
}
