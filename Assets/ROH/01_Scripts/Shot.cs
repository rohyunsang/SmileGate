using UnityEngine;

public class Shot : MonoBehaviour
{

    Vector3 m_vecMouseDownPos;

    void Update()
    {
#if UNITY_EDITOR
        // 마우스 클릭 시
        if (Input.GetMouseButtonDown(0))
#else
        // 터치 시
        if (Input.touchCount > 0)
#endif
        {

#if UNITY_EDITOR
            m_vecMouseDownPos = Input.mousePosition;
#else
            m_vecMouseDownPos = Input.GetTouch(0).position;
            if(Input.GetTouch(0).phase != TouchPhase.Began)
                return;
#endif
            // if( FindObjectOfType<Player>().iSShot == false ) return;

            // 마우스 클릭 위치를 카메라 스크린 월드포인트로 변경합니다.
            Vector2 pos = Camera.main.ScreenToWorldPoint(m_vecMouseDownPos);

            // Raycast함수를 통해 부딪치는 collider를 hit에 리턴받습니다.
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.tag == "Ghost")
            {
                hit.collider.gameObject.GetComponent<Ghost>().TakeDamage(1);
            }
        }
    }
}
