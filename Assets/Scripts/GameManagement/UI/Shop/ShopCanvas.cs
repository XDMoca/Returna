using UnityEngine;

public class ShopCanvas : MonoBehaviour
{
	[SerializeField]
	private GameObject ShopContent;

	public void AddShopItemButton(GameObject shopItemButton)
	{
		shopItemButton.transform.SetParent(ShopContent.transform, false);
	}
}
