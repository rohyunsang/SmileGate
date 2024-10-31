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
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스의 월드 좌표
            if (rc.railCollider.OverlapPoint(mousePosition)) // 마우스 위치가 콜라이더 안에 있는지 확인
            {
                rc.ChangeState(rc._holdState);
            }
        }

    }

    public void OnStateExit()
    {

    }
}
