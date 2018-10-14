using UnityEngine;

public class NotificationHandler : MonoBehaviour
{

	public static NotificationHandler instance = null;
	private NotificationCanvas notificationInstance;
	[SerializeField]
	private float NotificationDuration;
	[SerializeField]
	private GameObject NotificationCanvasPrefab;

	[SerializeField]
	private Color notificationPanelColor;
	[SerializeField]
	private Color errorNotificationPanelColor;

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

	public void DisplayErrorNotification(string notificationMessage)
	{
		InstantiateNotification();
		notificationInstance.Display(notificationMessage, NotificationDuration, errorNotificationPanelColor);
		MenuSoundSource.instance.PlayActionFailedSound();
	}

	public void DisplayNotification(string notificationMessage)
	{
		InstantiateNotification();
		notificationInstance.Display(notificationMessage, NotificationDuration, notificationPanelColor);
		MenuSoundSource.instance.PlayActionSuccessSound();
	}

	private void InstantiateNotification()
	{
		if (notificationInstance == null)
		{
			notificationInstance = Instantiate(NotificationCanvasPrefab).GetComponent<NotificationCanvas>();
		}
	}
}
