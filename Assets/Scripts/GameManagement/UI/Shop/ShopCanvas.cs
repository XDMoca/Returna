using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopCanvas : MonoBehaviour
{
	[SerializeField]
	private GameObject ShopContent;
	[SerializeField]
	private TextMeshProUGUI ItemDetailNameText;
	[SerializeField]
	private TextMeshProUGUI ItemDetailDamageText;
	[SerializeField]
	private TextMeshProUGUI ItemDetailFireRateText;
	[SerializeField]
	private TextMeshProUGUI ItemDetailDescriptionText;

	public void AddShopItemButton(GameObject shopItemButton)
	{
		shopItemButton.transform.SetParent(ShopContent.transform, false);
	}

	public void SetFirstElementAsActive()
	{
		EventSystem.current.SetSelectedGameObject(ShopContent.transform.GetChild(0).gameObject);
	}

	public void SetItemDetails(ShopItem selectedShopItem)
	{
		ItemDetailNameText.text = selectedShopItem.DisplayName;
		ItemDetailDamageText.text = "Damage: " + selectedShopItem.DisplayDamage;
		ItemDetailFireRateText.text = "Fire Rate: " + selectedShopItem.DisplayFireRate;
		ItemDetailDescriptionText.text = selectedShopItem.Weapon.Description;
	}
}