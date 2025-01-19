using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("# Component")]
    [HideInInspector] public Rigidbody2D rigidBody;
    [HideInInspector] public Animator anim;
    [HideInInspector] public SpriteRenderer spriteRenderer;
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

        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stat = GetComponent<PlayerStat>();
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
        CurrentState?.OnStateExit();
        CurrentState = playerState;
        CurrentState.OnStateEnter(this);
    }

    void UpdateState()
    {
        CurrentState?.OnStateUpdate();
    }

    public bool CheckAvailableState()
    {
        return (CurrentState == _idleState || CurrentState == _moveState);
    }
}
