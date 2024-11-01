using UnityEngine;

public class Shot : MonoBehaviour
{
    private PlayerController controller;
    Vector3 m_vecMouseDownPos;


    private void Start()
    {
        controller = MainManager.instance.playerController;
    }
    void Update()
    {

        // 마우스 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlaySfx(AudioManager.SFX.SFX_SHOT);

            // 마우스 클릭 위치를 저장
            m_vecMouseDownPos = Input.mousePosition;

            // 마우스 클릭 위치를 카메라 스크린 월드포인트로 변경합니다.
            Vector2 pos = Camera.main.ScreenToWorldPoint(m_vecMouseDownPos);

            // Raycast함수를 통해 부딪치는 collider를 hit에 리턴받습니다.
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.tag == "Ghost")
            {
                int randNum = Random.Range(0, 2);
                if (randNum == 0)
                    AudioManager.Instance.PlaySfx(AudioManager.SFX.SFX_DOG1);
                else if (randNum == 1)
                    AudioManager.Instance.PlaySfx(AudioManager.SFX.SFX_DOG2);
                hit.collider.gameObject.GetComponent<Ghost>().TakeDamage(1);
            }
        }
    }
}
