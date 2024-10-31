using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [Header("# Stat")]
    public int healthCount;

    [Header("# Movement")]
    public float moveSpeed;
    public float jumpSpeed;

    [Header("# Swamp")]
    public float swampDelay;
    public float swampEscapeForce;
    public float swampTimer;


    private void Update()
    {
        if(healthCount <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
