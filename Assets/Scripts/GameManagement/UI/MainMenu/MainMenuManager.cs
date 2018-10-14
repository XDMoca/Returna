using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public Button ContinueButton;

	void Start()
	{
		ContinueButton.interactable = StartGameManager.instance.SaveFileExists();
	}

	public void StartNewGame()
	{
		StartGameManager.instance.StartNewGame();
	}

	public void ContinueGame()
	{
		StartGameManager.instance.LoadSavedGame();
	}
}
