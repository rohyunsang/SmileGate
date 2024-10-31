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
        if (!controller.CheckAvailableState())
            return;

        // ���콺 Ŭ�� ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� ��ġ�� ����
            m_vecMouseDownPos = Input.mousePosition;

            // ���콺 Ŭ�� ��ġ�� ī�޶� ��ũ�� ��������Ʈ�� �����մϴ�.
            Vector2 pos = Camera.main.ScreenToWorldPoint(m_vecMouseDownPos);

            // Raycast�Լ��� ���� �ε�ġ�� collider�� hit�� ���Ϲ޽��ϴ�.
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.tag == "Ghost")
            {
                hit.collider.gameObject.GetComponent<Ghost>().TakeDamage(1);
            }
        }
    }
}
