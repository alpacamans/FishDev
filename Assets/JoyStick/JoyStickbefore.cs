using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickbefore : MonoBehaviour
{


    // ����
    public Transform Stick;         // ���̽�ƽ.
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;
    // �����
    private Vector3 StickFirstPos;  // ���̽�ƽ�� ó�� ��ġ.
    private Vector3 JoyVec;         // ���̽�ƽ�� ����(����)
    private float Radius;           // ���̽�ƽ ����� �� ����.

    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        // ĵ���� ũ�⿡���� ������ ����.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
        Debug.Log("�۵���");
    }

  

    // �巡��
    public void Drag(BaseEventData _Data)
    {
        Debug.Log("�۵���");

        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        // ���̽�ƽ�� �̵���ų ������ ����.(������,����,��,�Ʒ�)
        JoyVec = (Pos - StickFirstPos).normalized;

        // ���̽�ƽ�� ó�� ��ġ�� ���� ���� ��ġ�ϰ��ִ� ��ġ�� �Ÿ��� ���Ѵ�.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        // �Ÿ��� ���������� ������ ���̽�ƽ�� ���� ��ġ�ϰ� �ִ� ������ �̵�.
        if (Dis < Radius)
            Stick.position = StickFirstPos + JoyVec * Dis;
        // �Ÿ��� ���������� Ŀ���� ���̽�ƽ�� �������� ũ�⸸ŭ�� �̵�.
        else
        {
            Stick.position = StickFirstPos + JoyVec * Radius;
        }
        if (JoyVec.x > 0)
        {
            right = true;
            left = false;
        }
        else if (JoyVec.x < 0)
        {
            left = true;
            right = false;
        }
        else
        {
            left = false;
            right = false;
        }
        if (JoyVec.y > 0)
        {
            up = true;
            down = false;
        }
        else if (JoyVec.y < 0)
        {
            up = true;
            down = false;
        }
        else
        {
            up = false;
            down = false;
        }
        Debug.Log("up=" + up + "down=" + down + "left=" + left + "right=" + right);
    }

    // �巡�� ��.
    public void DragEnd()
    {
        Stick.position = StickFirstPos; // ��ƽ�� ������ ��ġ��.
        JoyVec = Vector3.zero;          // ������ 0����.
    }
}