using UnityEngine;

public class InteractionManager : MonoBehaviour
{

	private DialogueManager dialogueManager;
	private IInteractable interactionTarget;
	private SceneTransitionManager sceneTransitionManager;

	[SerializeField]
	private GameObject interactionIndicatorPrefab;
	private InteractionIndicator interactionIndicator;

	[ReadOnly]
	public bool InteractionTargetInRange;
	[ReadOnly]
	public bool Interacting;
	[SerializeField]
	private float interactionDetectionRange;
	[SerializeField]
	private float interactionDetectionWidth;
	[SerializeField]
	private bool DebugMode;

	void Start()
	{
		dialogueManager = FindObjectOfType<DialogueManager>();
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
		if (interactionTarget is InteractableEntity)
		{
			InteractableEntity target = interactionTarget as InteractableEntity;
			if (Interacting)
			{
				Interacting = dialogueManager.ShowNextSentence();
				if (!Interacting && target.IsFightable)
				{
					sceneTransitionManager.GoToBattle(target.Vehicle);
				}
			}
			else
			{
				Interacting = true;
				dialogueManager.StartDialog(target.name, target.GetDialogue());
			}
		}

		else if (interactionTarget is InteractableDoor)
		{
			InteractableDoor target = interactionTarget as InteractableDoor;
			sceneTransitionManager.GoToNextArea(target.NextAreaName, target.NextAreaSpawnPointIdentifier);
			Interacting = false;
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
