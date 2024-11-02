using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("# State")]
    public bool downState;

    private void Awake()
    {
        downState = false;
    }


    private void Update()
    {
        if(healthCount <= 0)
        {
            SceneManager.LoadScene("Result");
            Debug.Log("Game Over");
        }
    }
}
