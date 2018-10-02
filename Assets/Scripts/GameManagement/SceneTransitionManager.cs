using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

	private Animator animator;
	private GameObject player;
	private string worldSceneName = "Scenes/TownScene";
	private ESpawnPointIdentifiers nextSceneSpawnPointIdentifier;
	public ESceneType currentSceneType;
	private BattleManager battleManager;
	private DialogueManager dialogueManager;

	public event EventHandler OnLevelLoad;

	[SerializeField]
	private GameObject playerPrefab;

	public PostBattleInformation currentOpponentInformation = null;

	void Awake()
	{
		currentSceneType = ESceneType.Town;
		animator = GetComponent<Animator>();
		battleManager = GetComponent<BattleManager>();
		SceneManager.sceneLoaded += OnLevelLoaded;

		if (player == null)
		{
			player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
			dialogueManager = player.GetComponent<DialogueManager>();
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

	public void GoToBattle(OpponentCharacter opponent)
	{
		currentOpponentInformation = opponent.PostBattleInformation;
		battleManager.SetupBattleScenario(opponent.Vehicle);
		currentSceneType = ESceneType.Arena;
		SceneManager.LoadScene("Scenes/Arenas/BasicArena");
	}

	private void OnReturnFromBattle()
	{
		dialogueManager.StartDialogue(currentOpponentInformation.PlayerVictoryDialogue);
		InventoryManager.instance.EarnMoney(currentOpponentInformation.PrizeMoney);
		currentOpponentInformation = null;
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
