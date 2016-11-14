using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControleTexto : MonoBehaviour {
	public Text hud;
	Player player;

	void Start () {
		hud = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
//		hud.text = "Vida " + player.health + " / " + player.maxhealth;
	}
}
