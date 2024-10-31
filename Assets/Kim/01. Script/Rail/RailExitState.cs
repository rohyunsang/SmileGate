using UnityEngine;

public class RailExitState : MonoBehaviour, IRailState
{
    RailController rc;

    public void OnStateEnter(RailController controller)
    {
        if (rc == null)
            rc = controller;
        rc.playerController.transform.position = rc.smagaeSpawnPoint.position;
        rc.playerController.ChangeState(rc.playerController._middleState);
        rc.playerController.rigidBody.linearVelocityY = 0;
        rc.animator.SetBool("Exit", true);
    }

    public void OnStateUpdate()
    {

    }

    public void OnStateExit()
    {
        rc.animator.SetBool("Exit", false);
    }
}
