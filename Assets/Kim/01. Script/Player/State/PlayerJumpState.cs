using UnityEngine;

public class PlayerJumpState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;

        pc.rigidBody.AddForceY(pc.stat.jumpSpeed, ForceMode2D.Impulse);
        pc.anim.SetBool("Jump", true);
        AudioManager.Instance.PlaySfx(AudioManager.SFX.SFX_JUMP);
    }

    public void OnStateUpdate()
    {
        if(pc.rigidBody.linearVelocityY < 0.5)
        {
            pc.ChangeState(pc._middleState);
        }
    }

    public void OnStateExit()
    {
        pc.anim.SetBool("Jump", false);
    }
}
