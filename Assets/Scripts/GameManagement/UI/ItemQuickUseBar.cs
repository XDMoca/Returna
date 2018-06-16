using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemQuickUseBar : MonoBehaviour {

	[SerializeField]
	private Text[] itemText;

	[SerializeField]
	private Color selectedColor;

	[SerializeField]
	private Color unselectedColor;

	private int selectedItemIndex = 0;

	private InventoryManager.InventoryItem[] itemsOnQuickBar;
	
	void Start () {
	}

	public void setItems(InventoryManager.InventoryItem[] items)
	{
		itemsOnQuickBar = items;
		for (int i = 0; i < itemsOnQuickBar.Length; ++i)
		{
			itemText[i].text = items[i].item.Name + " x" + items[i].count;
		}
		HighlightSelectedItem();
	}

	public InventoryManager.InventoryItem GetSelectedItem()
	{
		return itemsOnQuickBar[selectedItemIndex];
	}

	public void SelectNextItem()
	{
		++selectedItemIndex;
		if (selectedItemIndex >= itemsOnQuickBar.Length)
			selectedItemIndex = 0;
		HighlightSelectedItem();
	}

	public void SelectPreviousItem()
	{
		--selectedItemIndex;
		if (selectedItemIndex < 0)
			selectedItemIndex = itemsOnQuickBar.Length-1;
		HighlightSelectedItem();
	}

	private void HighlightSelectedItem()
	{
		for(int i=0; i<itemsOnQuickBar.Length; ++i)
		{
			if (i == selectedItemIndex)
			{
				itemText[i].color = selectedColor;
			}
			else
			{
				itemText[i].color = unselectedColor;
			}
		}
	}



}
