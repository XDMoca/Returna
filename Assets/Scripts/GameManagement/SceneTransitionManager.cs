using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
	public static SceneTransitionManager instance = null;

	private Animator animator;
	private GameObject player;
	private string worldSceneName = "Scenes/TownScene";
	private ESpawnPointIdentifiers nextSceneSpawnPointIdentifier;
	public ESceneType currentSceneType;
	private BattleManager battleManager;

	public event EventHandler OnLevelLoad;

	[SerializeField]
	private GameObject playerPrefab;

	private DialoguePartnerInformation currentOpponent = null;

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
		currentSceneType = ESceneType.Town;
		animator = GetComponent<Animator>();
		battleManager = GetComponent<BattleManager>();
		SceneManager.sceneLoaded += OnLevelLoaded;

		if (player == null)
		{
			player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
			BindCameraToPlayer();
		}
		animator.SetTrigger("FadeIn");
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		if (OnLevelLoad != null)
			OnLevelLoad(this, new EventArgs());
	}

	public void GoToNextArea(string NextAreaName, ESpawnPointIdentifiers NextAreaSpawnPointIdentifier)
	{
		currentSceneType = ESceneType.Town;
		worldSceneName = NextAreaName;
		nextSceneSpawnPointIdentifier = NextAreaSpawnPointIdentifier;
		animator.SetTrigger("FadeOut");
	}

	private void LoadNextLevel()
	{
		SceneManager.LoadScene(worldSceneName);
	}

	public void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (currentSceneType == ESceneType.Town)
		{
			player.SetActive(true);
			if (nextSceneSpawnPointIdentifier != ESpawnPointIdentifiers.OriginalPosition)
			{
				AreaSpawnPoint spawnPoint = FindObjectsOfType<AreaSpawnPoint>().Where(sP => sP.Identifier == nextSceneSpawnPointIdentifier).FirstOrDefault();
				player.transform.position = spawnPoint.transform.position;
			}
			else
			{
				OnReturnFromBattle();
			}
			BindCameraToPlayer();
			animator.SetTrigger("FadeIn");
		}
		else if (currentSceneType == ESceneType.Arena)
		{
			player.SetActive(false);
			battleManager.SetupBattle();
			animator.SetTrigger("FadeIn");
		}

		if (OnLevelLoad != null)
			OnLevelLoad(this, new EventArgs());
	}

	public void GoToBattle(DialoguePartnerInformation opponentInformation)
	{
		currentOpponent = opponentInformation;
		battleManager.SetupBattleScenario(opponentInformation.Vehicle);
		currentSceneType = ESceneType.Arena;
		SceneManager.LoadScene("Scenes/Arenas/BasicArena");
	}

	private void OnReturnFromBattle()
	{
		DialogueMenuManager.instance.InitiateDialogue(currentOpponent, currentOpponent.PlayerVictoryDialogue);
		currentOpponent = null;
	}

	public void ReturnToWorld()
	{
		currentSceneType = ESceneType.Town;
		SceneManager.LoadScene(worldSceneName);
	}

	private void BindCameraToPlayer()
	{
		Camera.main.GetComponent<CameraControl>().player = player.transform;
	}
}
