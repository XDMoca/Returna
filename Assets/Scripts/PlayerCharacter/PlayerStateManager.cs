using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InteractionInterface))]
[RequireComponent(typeof(SoundPlayer))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerStateManager : AStateMachine
{

	[HideInInspector]
	public InputManager inputManager;
	[HideInInspector]
	public Transform cameraTransform;
	[HideInInspector]
	public new Rigidbody rigidbody;

	public PlayerStatesContainer states;

	[HideInInspector]
	public Animator animator;
	[HideInInspector]
	public InteractionInterface interactionInterface;
	[HideInInspector]
	public SoundPlayer soundPlayer;

	void Start()
	{
		inputManager = GetComponent<InputManager>();
		animator = GetComponent<Animator>();
		interactionInterface = GetComponent<InteractionInterface>();
		rigidbody = GetComponent<Rigidbody>();
		soundPlayer = GetComponent<SoundPlayer>();
		cameraTransform = Camera.main.transform;

		currentState = states.FreeMovement;
		currentState.SetupStateManagerReference(this);
	}
}
