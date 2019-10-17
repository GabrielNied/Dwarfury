using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	GameObject inventoryPanel;
	GameObject slotPanel;

	ItemDatabase database;
	ItemData itemdata;

	public GameObject inventorySlot;
	public GameObject inventoryItem;

	public bool noInv = false;
	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject> ();

	void Start()
	{
		database = GetComponent<ItemDatabase> ();
		itemdata = GetComponent<ItemData> ();

		slotAmount = 12;
		inventoryPanel = GameObject.Find ("Inventory Panel");
		slotPanel = inventoryPanel.transform.Find ("Slot Panel").gameObject;
		for (int i = 0; i < slotAmount; i++)
		{
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].GetComponent<Slot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);
		}

		AddItem (0);
		AddItem (1);
		AddItem (1);
		AddItem (1);
		AddItem (1);
		AddItem (1);
		AddItem (2);
		AddItem (2);
		AddItem (3);
		AddItem (4);
		AddItem (5);
	}
		
	void Update(){
		if (Input.GetKeyDown(KeyCode.I))
		{
			noInv = !noInv;
		}

		if (noInv)
		{
			inventoryPanel.SetActive(true);
		}

		if (!noInv)
		{
			inventoryPanel.SetActive(false);
		}
	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.FetchItemByID (id);
		if (itemToAdd.Estacavel && CheckIfItemIsInInventory(itemToAdd))
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].ID == id)
				{
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}
			}
		}
		else{
			for (int i = 0; i < items.Count; i++)
			{
				if (items [i].ID == -1)
				{
					items [i] = itemToAdd;
					GameObject itemObj = Instantiate (inventoryItem);
					itemObj.GetComponent<ItemData> ().item = itemToAdd;
					itemObj.GetComponent<ItemData> ().amount = 1;
					itemObj.GetComponent<ItemData> ().slot = i;
					itemObj.transform.SetParent (slots[i].transform);
					itemObj.transform.position = Vector2.zero;
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					break;
				}
			}
		}
	}
	bool CheckIfItemIsInInventory(Item item)
	{
		for (int i = 0; i < items.Count; i++)
			if (items[i].ID == item.ID)
				return true;
		return false;
	}
}
