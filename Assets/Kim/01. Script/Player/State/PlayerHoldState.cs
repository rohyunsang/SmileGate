using UnityEngine;

public class PlayerHoldState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;

        pc.rigidBody.linearVelocityY = 0;
        pc.spriteRenderer.enabled = false;
    }

    public void OnStateUpdate()
    {
        pc.rigidBody.linearVelocityX = pc.stat.moveSpeed;
    }

    public void OnStateExit()
    {
        pc.spriteRenderer.enabled = true;
    }
}