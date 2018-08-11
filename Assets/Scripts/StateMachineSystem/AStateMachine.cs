using UnityEngine;

public abstract class AStateMachine : MonoBehaviour {

	protected IState currentState;

	void FixedUpdate () {

		IState newState = currentState.CheckTransition();
		if (currentState != newState)
		{
			currentState.ExitState();
			currentState = newState;
			currentState.SetupStateManagerReference(this);
			currentState.EnterState();
		}
		currentState.StateUpdate();
		currentState.AnimatorUpdate();
	}
}
