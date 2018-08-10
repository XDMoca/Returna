using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

	[HideInInspector]
	public InputManager inputManager;
	[HideInInspector]
	public Transform cameraTransform;
	[HideInInspector]
	public new Rigidbody rigidbody;

	public PlayerStatesContainer states;
	IPlayerState currentState;

	[HideInInspector]
	public Animator animator;
	[HideInInspector]
	public InteractionManager interactionManager;
	[HideInInspector]
	public SoundPlayer soundPlayer;

	void Start()
	{
		inputManager = GetComponent<InputManager>();
		currentState = states.FreeMovement;
		animator = GetComponent<Animator>();
		interactionManager = GetComponent<InteractionManager>();
		rigidbody = GetComponent<Rigidbody>();
		soundPlayer = GetComponent<SoundPlayer>();
		cameraTransform = Camera.main.transform;
	}

	void FixedUpdate()
	{
		IPlayerState newState = currentState.CheckTransition(this);
		if (currentState != newState)
		{
			currentState = newState;
			currentState.StateEntered(this);
		}
		currentState.StateUpdate(this);
		currentState.AnimatorUpdate(this);
	}
}
