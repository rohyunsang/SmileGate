using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseChaser : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage; // 마우스 커서 이미지의 RectTransform

    private void Start()
    {
        // 기본 커서 숨기기
        Cursor.visible = false;
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        // 마우스 위치 가져오기
        Vector2 mousePosition = Input.mousePosition;

        // 커서 이미지를 마우스 위치로 이동
        cursorImage.position = mousePosition;
    }
}
