using UnityEngine;

public class PlayerMiddleState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    private float animationCounter;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;

        animationCounter = 0;
        pc.anim.SetBool("Middle", true);
    }

    public void OnStateUpdate()
    {
        animationCounter += Time.deltaTime;
        if (animationCounter > 0.3)
        {
            pc.ChangeState(pc._downState);
        }
    }

    public void OnStateExit()
    {
        pc.anim.SetBool("Middle", false);
    }
}