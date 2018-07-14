using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState{
	void StateUpdate(EnemyStateManager stateManager);
	IEnemyState CheckTransition(EnemyStateManager stateManager);
	void AnimatorUpdate(EnemyStateManager stateManager);
	void StateEntered(EnemyStateManager stateManager);
}
