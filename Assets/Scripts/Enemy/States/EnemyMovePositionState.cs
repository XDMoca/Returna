using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMovePositionState : IEnemyState
{
	[SerializeField]
	private float stoppingDistanceFromPlayer;
	[SerializeField]
	private float attackCooldown;
	[SerializeField]
	private float attackRange;

	private float timeSinceLastAttack = 0;

	public void AnimatorUpdate(EnemyStateManager stateManager)
	{
	}

	public IEnemyState CheckTransition(EnemyStateManager stateManager)
	{
		if (!stateManager.playerSensor.playerInRange)
		{
			return stateManager.states.Idle;
		}
		if(CanAttack(stateManager))
		{
			timeSinceLastAttack = 0;
			return stateManager.states.Attack;
		}
		return this;
	}

	public void StateEntered(EnemyStateManager stateManager)
	{
		stateManager.navAgent.SetDestination(stateManager.playerStatus.transform.position);
		stateManager.navAgent.stoppingDistance = stoppingDistanceFromPlayer;
		stateManager.navAgent.isStopped = false;
	}

	public void StateUpdate(EnemyStateManager stateManager)
	{
		timeSinceLastAttack += Time.deltaTime;
		stateManager.navAgent.SetDestination(stateManager.playerStatus.transform.position);
	}

	private bool PlayerInAttackRange(EnemyStateManager stateManager)
	{
		return (stateManager.transform.position - stateManager.playerStatus.transform.position).magnitude < attackRange;
	}

	private bool CanAttack(EnemyStateManager stateManager)
	{
		return timeSinceLastAttack >= attackCooldown && PlayerInAttackRange(stateManager);
	}
}
