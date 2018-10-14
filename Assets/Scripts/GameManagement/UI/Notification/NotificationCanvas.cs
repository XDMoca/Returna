using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationCanvas : MonoBehaviour
{

	[SerializeField]
	private TextMeshProUGUI MessageText;
	[SerializeField]
	private Image panelBackground;

	private Animator animator;

	private float timeToDestroy = 0;
	private float timeSinceShown = 0;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Display(string messageText, float duration, Color panelColour)
	{
		timeSinceShown = 0;
		MessageText.text = messageText;
		timeToDestroy = duration;
		panelBackground.color = panelColour;
		animator.SetTrigger("Appear");
	}

	private void Update()
	{
		timeSinceShown += Time.deltaTime;
		if (timeSinceShown > timeToDestroy)
			Destroy(gameObject);
	}
}
