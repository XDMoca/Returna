using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {
    void StateUpdate();
    IState CheckTransition();
    void AnimatorUpdate();
    void EnterState();
	void ExitState();
	void SetupStateManagerReference(AStateMachine stateManager);
}
