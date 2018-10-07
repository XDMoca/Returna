using TMPro;
using UnityEngine;

public class ShopItemButton : MonoBehaviour
{

	[SerializeField]
	private TextMeshProUGUI nameText;
	[SerializeField]
	private TextMeshProUGUI priceText;

	public void Initialise(ShopItem shopItem)
	{
		nameText.text = shopItem.Weapon.Name;
		priceText.text = "$" + shopItem.Price.ToString();
	}
}
