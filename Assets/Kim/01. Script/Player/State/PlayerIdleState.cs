using UnityEngine;

public class PlayerIdleState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    private float startTimer;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;

        startTimer = 0;
    }

    public void OnStateUpdate()
    {
        if (startTimer > 2)
        {
            pc.ChangeState(pc._moveState);
        }
        startTimer += Time.deltaTime;
    }

    public void OnStateExit()
    {

    }
}
