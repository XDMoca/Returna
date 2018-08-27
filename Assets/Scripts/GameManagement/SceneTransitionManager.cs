using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

	private Animator animator;
	private GameObject player;
	private string nextSceneName;
	private ESpawnPointIdentifiers nextSceneSpawnPointIdentifier;
	private ESceneType currentSceneType;
	private BattleSetupManager battleSetup;

	[SerializeField]
	private GameObject playerPrefab;

	void Awake()
	{
		currentSceneType = ESceneType.Town;
		animator = GetComponent<Animator>();
		battleSetup = GetComponent<BattleSetupManager>();
		SceneManager.sceneLoaded += OnLevelLoaded;

		if (player == null)
		{
			player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
			Camera.main.GetComponent<CameraControl>().player = player.transform;
		}
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(gameObject);
	}
	
	public void GoToNextArea(string NextAreaName, ESpawnPointIdentifiers NextAreaSpawnPointIdentifier)
	{
		currentSceneType = ESceneType.Town;
		nextSceneName = NextAreaName;
		nextSceneSpawnPointIdentifier = NextAreaSpawnPointIdentifier;
		animator.SetTrigger("FadeOut");
	}

	private void LoadNextLevel()
	{
		SceneManager.LoadScene(nextSceneName);
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
			animator.SetTrigger("FadeIn");
		}
		else
		{
			player.SetActive(false);
			battleSetup.SetupBattle();
		}
	}

	public void GoToBattle(GameObject enemyVehicle)
	{
		battleSetup.SetupBattleScenario(enemyVehicle);
		currentSceneType = ESceneType.Arena;
		SceneManager.LoadScene("Scenes/Arenas/BasicArena");
	}
}
