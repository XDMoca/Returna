using UnityEngine;

public class GameLoadManager : MonoBehaviour
{

	[SerializeField]
	private GameObject GameManagerPrefab;
	[SerializeField]
	private GameObject CameraPrefab;

	void Start()
	{
		GameObject gameManager = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		if (Camera.main == null)
		{
			Instantiate(CameraPrefab);
		}
		if (gameManager == null)
		{
			Instantiate(GameManagerPrefab);
		}
	}
}
