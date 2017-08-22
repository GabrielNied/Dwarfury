using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot;

	private Inventory inv;
	private Tooltip tooltip;
	private Vector2 offset;

	void Start(){
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		tooltip = inv.GetComponent<Tooltip> ();
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (item != null){
			this.transform.SetParent (this.transform.parent.parent);
			this.transform.position = eventData.position - offset;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}
		
	public void OnDrag (PointerEventData eventData)
	{
		if (item != null){
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		this.transform.SetParent (inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
	}


	public void OnPointerEnter (PointerEventData eventData)
	{
		tooltip.Activate (item);
	}


	public void OnPointerExit (PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}
}