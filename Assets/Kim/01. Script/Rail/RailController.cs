using UnityEngine;

public class RailController : MonoBehaviour
{
    public Collider2D railCollider;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform smagaeSpawnPoint;

    [HideInInspector] public PlayerController playerController;
    [HideInInspector] public bool onRailFlag;
    [HideInInspector] public bool mouseClickDownFlag;

    public IRailState CurrentState
    {
        get; private set;
    }

    public IRailState _idleState, _holdState, _exitState;
    private void Awake()
    {
        if(animator == null)
            animator = GetComponent<Animator>();
        if(railCollider == null)
            railCollider = GetComponent<Collider2D>();
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();

        playerController = FindFirstObjectByType<PlayerController>();

        _idleState = gameObject.AddComponent<RailIdleState>();
        _holdState = gameObject.AddComponent<RailHoldState>();
        _exitState = gameObject.AddComponent<RailExitState>();
    }

    private void Start()
    {
        onRailFlag = false;
        mouseClickDownFlag = false;

        ChangeState(_idleState);
    }

    private void Update()
    {
        UpdateState();
    }

    public void ChangeState(IRailState state)
    {
        if (CurrentState != null)
            CurrentState.OnStateExit();

        CurrentState = state;
        CurrentState.OnStateEnter(this);
    }

    void UpdateState()
    {
        if (CurrentState != null)
            CurrentState.OnStateUpdate();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onRailFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onRailFlag = false;
    }
}
