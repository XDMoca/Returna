using UnityEngine;

public class BattleManager : MonoBehaviour
{
	[SerializeField]
	private GameObject playerVehicle;
	private GameObject enemyVehicle;

	private VehicleHealthManager playerHealth;
	private VehicleHealthManager enemyHealth;

	private SceneTransitionManager sceneTransition;

	void Start()
	{
		sceneTransition = GetComponent<SceneTransitionManager>();
	}

	public void SetupBattleScenario(GameObject enemyVehicle)
	{
		this.enemyVehicle = enemyVehicle;
	}

	public void SetupBattle()
	{
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(Constants.Tags.VehicleSpawnPoint);
		playerHealth = Instantiate(playerVehicle, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation).GetComponent<VehicleHealthManager>();
		enemyHealth = Instantiate(enemyVehicle, spawnPoints[1].transform.position, spawnPoints[1].transform.rotation).GetComponent<VehicleHealthManager>();
		playerHealth.OnHealthChange += (s, e) => CheckBattleStatus();
		enemyHealth.OnHealthChange += (s, e) => CheckBattleStatus();
	}

	private void CheckBattleStatus()
	{
		if (playerHealth.Health <= 0)
		{
			EndBattle();
		}
		if (enemyHealth.Health <= 0)
		{
			EndBattle();
		}
	}

	private void EndBattle()
	{
		sceneTransition.ReturnToWorld();
	}
}