using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("# Component")]
    public Rigidbody2D rigidBody;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    [HideInInspector] public PlayerStat stat;

    public IPlayerState _idleState, _moveState, _jumpState, _downState, _holdState, _middleState;
    public IPlayerState CurrentState
    {
        get; private set;
    }

    private void Awake()
    {
        #region Init Variable
        if (instance == null)
            instance = this;

        if(rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();

        if (anim == null)
            anim = GetComponent<Animator>();

        if(spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (stat == null)
            stat = FindFirstObjectByType<PlayerStat>();
        #endregion

        #region Init State
        _idleState = gameObject.AddComponent<PlayerIdleState>();
        _moveState = gameObject.AddComponent<PlayerMoveState>();
        _jumpState = gameObject.AddComponent<PlayerJumpState>();
        _downState = gameObject.AddComponent<PlayerDownState>();
        _holdState = gameObject.AddComponent<PlayerHoldState>();
        _middleState = gameObject.AddComponent<PlayerMiddleState>();
        #endregion
    }
    private void Start()
    {
        ChangeState(_idleState);
    }

    private void Update()
    {
        UpdateState();
    }

    public void ChangeState(IPlayerState playerState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnStateExit();
        }
        CurrentState = playerState;
        CurrentState.OnStateEnter(this);
    }

    void UpdateState()
    {
        if (CurrentState != null)
        {
            CurrentState.OnStateUpdate();
        }
    }

    public bool CheckAvailableState()
    {
        if (CurrentState == _idleState)
            return true;

        if (CurrentState == _moveState)
            return true;

        return false;

    }
}
