using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IPlayerState
{
    PlayerController pc;
    bool swampCheckFlag;
    float swampTimer;
    bool swampForceFlag;
    public void OnStateEnter(PlayerController controller)
    {
        if (pc == null)
            pc = controller;

        swampCheckFlag = false;
        swampTimer = 0;
        swampForceFlag = false;
        pc.anim.SetBool("Move", true);
    }

    public void OnStateUpdate()
    {
        #region Movement
        if (swampCheckFlag)
        {
            CheckSwampTimer();
            if(swampForceFlag)
            {
                pc.rigidBody.linearVelocityX = pc.stat.swampEscapeForce;
                Invoke(nameof(ChangeSwampFlag), pc.stat.swampDelay);
            }
            else
            {
                pc.rigidBody.linearVelocityX = pc.stat.moveSpeed / 4;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                swampForceFlag = true;
            }

        }
        else
        {
            pc.rigidBody.linearVelocityX = pc.stat.moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pc.ChangeState(pc._jumpState);
            }
        }
        #endregion
    }

    public void OnStateExit()
    {
        pc.anim.SetBool("Move", false);
    }

    void ChangeSwampFlag()
    {
        swampForceFlag = false;
    }

    void CheckSwampTimer()
    {
        swampTimer += Time.deltaTime;

        if (swampTimer > pc.stat.swampTimer)
        {
            pc.stat.healthCount--;
            swampTimer = 0;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            swampCheckFlag = true;
            pc.anim.speed = 0.5f;
        }

    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            swampCheckFlag = true;
            pc.anim.speed = 0.5f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            swampCheckFlag = true;
            pc.anim.speed = 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            swampCheckFlag = false;
            pc.anim.speed = 1f;
        }
    }
}
