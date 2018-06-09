using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour {

    private new Transform camera;
    private Animator animator;
    private SpriteRenderer sprite;
    [HideInInspector]
    public Transform player;

    [SerializeField]
    private Vector3 offsetFromPlayer;

    void Start () {
        DontDestroyOnLoad(gameObject);
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        camera = Camera.main.transform;
        Hide();
	}
	
	void Update () {
        transform.rotation = camera.rotation;
        transform.position = player.position + offsetFromPlayer;
	}

    public void Hide()
    {
        if (sprite == null || !sprite.enabled)
            return;
        sprite.enabled = false;
        animator.SetBool("Speak", false);
        animator.SetBool("Go", false);
    }

    public void Show(IInteractable interactionTarget)
    {
        if (sprite == null || sprite.enabled)
            return;
        sprite.enabled = true;
        animator.SetTrigger("Appear");
        SetInteractionType(interactionTarget);
    }

    private void SetInteractionType(IInteractable interactionTarget)
    {
        if (interactionTarget is InteractableEntity)
        {
           animator.SetBool("Speak", true);
        }

        else if (interactionTarget is InteractableDoor)
        {
            animator.SetBool("Go", true);
        }
    }
}
