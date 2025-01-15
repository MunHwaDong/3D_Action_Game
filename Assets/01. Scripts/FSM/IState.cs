public interface IState
{
    void EnterState();
    void UpdateState();
    void ExitState();
    StateMachine FSM { get; set; }
}