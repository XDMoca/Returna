public abstract class AState<T> : IState where T: AStateMachine
{

	protected T stateManager = null;

	public abstract void AnimatorUpdate();

	public abstract IState CheckTransition();

	public abstract void EnterState();

	public abstract void ExitState();

	public abstract void StateUpdate();

	public void SetupStateManagerReference(AStateMachine stateManager)
	{
		if (this.stateManager == null)
			this.stateManager = (T)stateManager;
	}
}
