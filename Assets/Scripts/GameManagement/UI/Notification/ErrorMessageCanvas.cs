using TMPro;
using UnityEngine;

public class ErrorMessageCanvas : MonoBehaviour
{

	[SerializeField]
	private TextMeshProUGUI MessageText;
	private Animator animator;

	private float timeToDestroy = 0;
	private float timeSinceShown = 0;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Display(string messageText, float duration)
	{
		timeSinceShown = 0;
		MessageText.text = messageText;
		timeToDestroy = duration;
		animator.SetTrigger("Appear");
	}

	private void Update()
	{
		timeSinceShown += Time.deltaTime;
		if (timeSinceShown > timeToDestroy)
			Destroy(gameObject);
	}
}
