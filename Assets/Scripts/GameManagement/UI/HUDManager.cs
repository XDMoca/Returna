using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

	[SerializeField]
	Text HPText;
	[SerializeField]
	Text TimeText;
	[SerializeField]
	Text LevelText;
	[SerializeField]
	Slider ExpSlider;

	private TimeManager timeManager;
	private PlayerExpManager playerExp;
	private PlayerHealthManager playerHealth;

	void Start()
	{
		timeManager = GetComponent<TimeManager>();
		GameObject player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
		playerHealth = player.GetComponent<PlayerHealthManager>();
		playerExp = player.GetComponent<PlayerExpManager>();

		timeManager.OnTick += (s, e) => UpdateTime();
		playerHealth.OnHPChange += (s, e) => UpdateHP();
		playerExp.OnExpChanged += (s, e) => UpdateExp();

		HPText.text = playerHealth.HPInformation;
		TimeText.text = timeManager.GetTime();
		ExpSlider.maxValue = playerExp.ExpToNextLevel;
		ExpSlider.value = playerExp.CurrentExp;
		LevelText.text = "Lv" + playerExp.CurrentLevel.ToString();
	}

	private void UpdateTime()
	{
		TimeText.text = timeManager.GetTime();
	}

	private void UpdateHP()
	{
		HPText.text = playerHealth.HPInformation;
	}

	private void UpdateExp()
	{
		ExpSlider.value = playerExp.CurrentExp;
		LevelText.text = "Lv" + playerExp.CurrentLevel.ToString();
	}
}
