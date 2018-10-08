using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour, ISelectHandler, ISubmitHandler, ICancelHandler
{

	[SerializeField]
	private TextMeshProUGUI nameText;
	[SerializeField]
	private TextMeshProUGUI priceText;

	private ShopItem shopItem;

	public void Initialise(ShopItem shopItem)
	{
		this.shopItem = shopItem;
		SetTextValues();
	}

	private void SetTextValues()
	{
		nameText.text = shopItem.DisplayName;
		priceText.text = InventoryManager.instance.OwnsWeapon(shopItem.Weapon) ? "SOLD" : "$" + shopItem.Price.ToString();
	}

	public void OnSelect(BaseEventData eventData)
	{
		ShopMenuManager.instance.UpdateItemDetailPanel(shopItem);
	}

	public void OnSubmit(BaseEventData eventData)
	{
		if (InventoryManager.instance.TryBuyWeapon(shopItem.Price, shopItem.Weapon))
		{
			SetTextValues();
		}
	}

	public void OnCancel(BaseEventData eventData)
	{
		ShopMenuManager.instance.CloseShopMenu();
	}
}
