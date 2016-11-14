using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public Player player;

	public Text Level;
	public Text Exp;
	public Text Ataque;
	public Text Defesa;
	public Text Vida;
	public Text Gold;

	void Start () {
	
	}

	void Update () {
		Level.text = "Level " + player.level; 
		Exp.text = "Exp " + player.exp + "/" + player.maxexp; 
		Ataque.text = "Ataque " + player.atk; 
		Defesa.text = "Defesa " + player.def; 
		Vida.text = "Vida " + player.health + "/" + player.maxhealth; 
		Gold.text = "Gold " + player.gold; 
	}
}
