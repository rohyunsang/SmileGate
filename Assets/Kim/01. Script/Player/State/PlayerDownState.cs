using UnityEngine;

public class PlayerDownState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    bool collisionCheckFlag;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;

        pc.anim.SetBool("Down", true);
        collisionCheckFlag = false;
    }

    public void OnStateUpdate()
    {
        if (collisionCheckFlag)
            pc.ChangeState(pc._moveState);
    }

    public void OnStateExit()
    {
        collisionCheckFlag = false;
        pc.anim.SetBool("Down", false);
    }

    // 바닥과의 충돌 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pc.stat.downState)
            return;

        collisionCheckFlag = true;

        if (collision.gameObject.CompareTag("Ground"))
        {
            collisionCheckFlag = true;
        }
    }
}
