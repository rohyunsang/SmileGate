using UnityEngine;

public class PlayerIdleState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;
    }

    public void OnStateUpdate()
    {
        pc.ChangeState(pc._moveState);
    }

    public void OnStateExit()
    {

    }
}
