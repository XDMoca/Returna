using System;
using UnityEngine;

public class InteractionInterface : MonoBehaviour
{
	public static InteractionInterface instance = null;
	[HideInInspector]
	public  IInteractable interactionTarget;
	private SceneTransitionManager sceneTransitionManager;

	[SerializeField]
	private GameObject interactionIndicatorPrefab;
	private InteractionIndicator interactionIndicator;
	
	[ReadOnly]
	public bool InteractionTargetInRange;
	
	public bool Interacting { get { return DialogueMenuManager.instance.InDialogue || ShopMenuManager.instance.IsShopMenuOpen; } }

	[SerializeField]
	private float interactionDetectionRange;
	[SerializeField]
	private float interactionDetectionWidth;
	[SerializeField]
	private bool DebugMode;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
		SetupInteractionIndicator();
	}

	private void Update()
	{
		if (DebugMode)
			DebugHelper.DrawBoxCastBox(transform.position, new Vector3(interactionDetectionWidth, 1, 0), transform.forward, transform.rotation, interactionDetectionRange, Color.blue, 0.1f);

		RaycastHit hit;
		bool didHitSomething = Physics.BoxCast(transform.position, new Vector3(interactionDetectionWidth, 1, 0), transform.forward, out hit, transform.rotation, interactionDetectionRange, LayerMask.GetMask(Constants.Layers.Interactable));
		if (didHitSomething)
		{
			InteractionTargetInRange = true;
			interactionTarget = hit.transform.GetComponent<IInteractable>();
			interactionIndicator.Show(interactionTarget);
		}
		else
		{
			InteractionTargetInRange = false;
			interactionTarget = null;
			interactionIndicator.Hide();
		}
	}

	public void Interact()
	{
		if (interactionTarget is InteractableDoor)
		{
			InteractableDoor target = interactionTarget as InteractableDoor;
			sceneTransitionManager.GoToNextArea(target.NextAreaName, target.NextAreaSpawnPointIdentifier);
		}
	}

	private void SetupInteractionIndicator()
	{
		if (interactionIndicator != null)
			return;
		interactionIndicator = Instantiate(interactionIndicatorPrefab).GetComponent<InteractionIndicator>();
		interactionIndicator.player = transform;
	}
}
