using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {
	public Inventory inv;

	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player") {
			inv.AddItem (0);
		}
	}
}
