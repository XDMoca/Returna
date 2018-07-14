using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyIdleState : IEnemyState
{
	[SerializeField]
	private Vector3 IdlePosition;

	public void AnimatorUpdate(EnemyStateManager stateManager)
	{
	}

	public IEnemyState CheckTransition(EnemyStateManager stateManager)
	{
		if (stateManager.playerSensor.playerInRange)
		{
			return stateManager.states.MovePosition;
		}

		return this;
	}

	public void StateEntered(EnemyStateManager stateManager)
	{
		stateManager.navAgent.SetDestination(IdlePosition);
		stateManager.navAgent.isStopped = false;
		stateManager.navAgent.stoppingDistance = 0.1f;
	}

	public void StateUpdate(EnemyStateManager stateManager)
	{
	}
}
