using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyStatesContainer {
	public EnemyIdleState Idle;
	public EnemyMovePositionState MovePosition;
	public EnemyAttackState Attack;
}
