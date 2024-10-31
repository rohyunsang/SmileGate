using UnityEngine;

public class RailHoldState : MonoBehaviour, IRailState
{
    RailController rc;
    Vector3 railUnderPos;

    public void OnStateEnter(RailController controller)
    {
        if (rc == null)
            rc = controller;

        rc.animator.SetBool("Hold", true);
        rc.playerController.ChangeState(rc.playerController._holdState);
    }

    public void OnStateUpdate()
    {
        rc.rb.linearVelocityX = rc.playerController.stat.moveSpeed - 0.2f;
        railUnderPos = new(rc.smagaeSpawnPoint.position.x, rc.smagaeSpawnPoint.position.y, 0);
        rc.playerController.transform.position = railUnderPos;


        if (Input.GetMouseButtonUp(0)) // 마우스 클릭을 감지
        {
            rc.ChangeState(rc._exitState);
        }
    }

    public void OnStateExit()
    {
        rc.rb.linearVelocityX = 0;
        rc.animator.SetBool("Hold", false);
    }
}