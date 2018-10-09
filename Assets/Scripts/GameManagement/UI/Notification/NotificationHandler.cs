using UnityEngine;

public class NotificationHandler : MonoBehaviour
{

	public static NotificationHandler instance = null;
	private ErrorMessageCanvas errorMessage;
	[SerializeField]
	private float NotificationDuration;
	[SerializeField]
	private GameObject errorMessageCanvasPrefab;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	public void Display(string notificationMessage)
	{
		if (errorMessage == null)
		{
			errorMessage = Instantiate(errorMessageCanvasPrefab).GetComponent<ErrorMessageCanvas>();
		}

		errorMessage.Display(notificationMessage, NotificationDuration);
	}
}
