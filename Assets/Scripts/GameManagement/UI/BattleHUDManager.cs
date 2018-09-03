using UnityEngine;
using UnityEngine.UI;

public class BattleHUDManager : MonoBehaviour {

	[SerializeField]
	private Slider playerHealthSlider;
	[SerializeField]
	private Slider enemyHealthSlider;

	private VehicleHealthManager playerHealth;
	private VehicleHealthManager enemyHealth;

	public void InitialiseHealthBars(VehicleHealthManager playerHealth, VehicleHealthManager enemyHealth)
	{
		this.playerHealth = playerHealth;
		this.enemyHealth = enemyHealth;

		playerHealthSlider.maxValue = playerHealth.MaxHealth;
		enemyHealthSlider.maxValue = enemyHealth.MaxHealth;

		playerHealth.OnHealthChange += (s, e) => UpdateHealthBars();
		enemyHealth.OnHealthChange += (s, e) => UpdateHealthBars();
	}

	private void UpdateHealthBars()
	{
		playerHealthSlider.value = playerHealth.Health;
		enemyHealthSlider.value = enemyHealth.Health;
	}
}
