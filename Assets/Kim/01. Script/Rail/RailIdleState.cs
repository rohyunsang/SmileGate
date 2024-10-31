using UnityEngine;

public class RailIdleState : MonoBehaviour, IRailState
{
    RailController rc;

    public void OnStateEnter(RailController controller)
    {
        if (rc == null)
            rc = controller;
    }

    public void OnStateUpdate()
    {
        if (!rc.onRailFlag)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺�� ���� ��ǥ
            if (rc.railCollider.OverlapPoint(mousePosition)) // ���콺 ��ġ�� �ݶ��̴� �ȿ� �ִ��� Ȯ��
            {
                rc.ChangeState(rc._holdState);
            }
        }

    }

    public void OnStateExit()
    {

    }
}
