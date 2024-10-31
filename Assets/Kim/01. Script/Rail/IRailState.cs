public interface IRailState
{
    public void OnStateEnter(RailController controller);
    public void OnStateUpdate();
    public void OnStateExit();
}