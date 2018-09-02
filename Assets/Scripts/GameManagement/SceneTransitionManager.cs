using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

	private Animator animator;
	private GameObject player;
	private string worldSceneName = "Scenes/TownScene";
	private ESpawnPointIdentifiers nextSceneSpawnPointIdentifier;
	private ESceneType currentSceneType;
	private BattleManager battleManager;

	[SerializeField]
	private GameObject playerPrefab;

	void Awake()
	{
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
			BindCameraToPlayer();
			animator.SetTrigger("FadeIn");
		}
		else
		{
			player.SetActive(false);
			battleManager.SetupBattle();
			animator.SetTrigger("FadeIn");
		}
	}

	public void GoToBattle(GameObject enemyVehicle)
	{
		battleManager.SetupBattleScenario(enemyVehicle);
		currentSceneType = ESceneType.Arena;
		SceneManager.LoadScene("Scenes/Arenas/BasicArena");
	}

	public void ReturnToWorld()
	{
		SceneManager.LoadScene(worldSceneName);
		currentSceneType = ESceneType.Town;
	}

	private void BindCameraToPlayer()
	{
		Camera.main.GetComponent<CameraControl>().player = player.transform;
	}
}
