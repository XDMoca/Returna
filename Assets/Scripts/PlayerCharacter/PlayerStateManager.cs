using UnityEngine;

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
	public InteractionManager interactionManager;
	[HideInInspector]
	public SoundPlayer soundPlayer;

	void Start()
	{
		inputManager = GetComponent<InputManager>();
		animator = GetComponent<Animator>();
		interactionManager = GetComponent<InteractionManager>();
		rigidbody = GetComponent<Rigidbody>();
		soundPlayer = GetComponent<SoundPlayer>();
		cameraTransform = Camera.main.transform;
		
		currentState = states.FreeMovement;
		currentState.SetupStateManagerReference(this);
	}
}
