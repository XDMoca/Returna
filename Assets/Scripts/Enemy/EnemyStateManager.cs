using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour {

	IEnemyState currentState;
	public EnemyStatesContainer states;

	[HideInInspector]
	public PlayerSensor playerSensor;
	[HideInInspector]
	public NavMeshAgent navAgent;
	[HideInInspector]
	public Animator animator;


	[HideInInspector]
	public PlayerStatusManager playerStatus;

	void Start()
	{
		currentState = states.Idle;
		playerSensor = GetComponent<PlayerSensor>();
		animator = GetComponent<Animator>();
		navAgent = GetComponent<NavMeshAgent>();
		playerStatus = GameObject.FindGameObjectWithTag(Constants.Tags.Player).GetComponent<PlayerStatusManager>();
	}

	void FixedUpdate()
	{
		IEnemyState newState = currentState.CheckTransition(this);
		if (currentState != newState)
		{
			currentState = newState;
			currentState.StateEntered(this);
		}
		currentState.StateUpdate(this);
		currentState.AnimatorUpdate(this);
	}
}
