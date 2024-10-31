using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseChaser : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // ���콺 Ŀ�� �̹����� RectTransform

    private void Start()
    {
        // �⺻ Ŀ�� �����
        Cursor.visible = false;
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        // ���콺 ��ġ ��������
        Vector2 mousePosition = Input.mousePosition;

        // Ŀ�� �̹����� ���콺 ��ġ�� �̵�
        cursorImage.position = mousePosition;
    }
}
