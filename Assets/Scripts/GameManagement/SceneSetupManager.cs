using UnityEngine;

public class SceneSetupManager : MonoBehaviour
{

	[SerializeField]
	private GameObject GameManagerPrefab;
	[SerializeField]
	private GameObject CameraPrefab;

	private void Awake()
	{
		if (Camera.main == null)
		{
			Instantiate(CameraPrefab);
		}
	}

	void Start()
	{
		GameObject gameManager = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		if (gameManager == null)
		{
			Instantiate(GameManagerPrefab);
		}
	}
}
