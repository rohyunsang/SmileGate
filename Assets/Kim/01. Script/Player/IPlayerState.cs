public interface IPlayerState
{
    public void OnStateEnter(PlayerController controller);
    public void OnStateUpdate();
    public void OnStateExit();
}