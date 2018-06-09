using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {

    [HideInInspector]
    public InputManager inputManager;
    [HideInInspector]
    public AnimationFlags animationFlags;
    [HideInInspector]
    public Transform cameraTransform;
    [HideInInspector]
    public new Rigidbody rigidbody;

    public PlayerStatesContainer states;
    IPlayerState currentState;

    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public PlayerStatusManager playerStatus;
    [HideInInspector]
    public LockOnManager lockOnManager;
    [HideInInspector]
    public InteractionManager interactionManager;

    void Start () {
        inputManager = GetComponent<InputManager>();
        currentState = states.FreeMovement;
        animator = GetComponent<Animator>();
        playerStatus = GetComponent<PlayerStatusManager>();
        animationFlags = GetComponent<AnimationFlags>();
        lockOnManager = GetComponent<LockOnManager>();
        interactionManager = GetComponent<InteractionManager>();
        rigidbody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }
	
	void FixedUpdate () {
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
