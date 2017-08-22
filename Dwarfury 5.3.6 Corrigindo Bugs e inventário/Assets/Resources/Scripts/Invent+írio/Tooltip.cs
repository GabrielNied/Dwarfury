using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
	private Item item;
	private string data;
	private GameObject tooltip;

	void Start(){
		tooltip = GameObject.Find ("Tooltip");
		tooltip.SetActive (false);
	}

	void Update(){
		if (tooltip.activeSelf) {
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(Item item){
		this.item = item;
		ConstructDataString ();
		tooltip.SetActive (true);
	}

	public void Deactivate(){
		tooltip.SetActive (false);
	}

	public void ConstructDataString(){
		if (item.Raridade == "Comum" && item.Tipo == "Item") {
			data = "<color=#ffffff><b>" + item.Title + "</b></color>\n\n" + item.Descricao + "\nTipo: " + item.Tipo + "\nRaridade: " + item.Raridade + "\nAtaque: " + item.Ataque + "\nDefesa: " + item.Defesa + "\nValor: " + item.Value;
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		}
		if (item.Raridade == "Incomum" && item.Tipo == "Item") {
			data = "<color=#458b00><b>" + item.Title + "</b></color>\n\n" + item.Descricao + "\nTipo: " + item.Tipo + "\nRaridade: " + item.Raridade + "\nAtaque: " + item.Ataque + "\nDefesa: " + item.Defesa + "\nValor: " + item.Value;
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		}
		if (item.Raridade == "Raro" && item.Tipo == "Item") {
			data = "<color=#1874cd><b>" + item.Title + "</b></color>\n\n" + item.Descricao + "\nTipo: " + item.Tipo + "\nRaridade: " + item.Raridade + "\nAtaque: " + item.Ataque + "\nDefesa: " + item.Defesa + "\nValor: " + item.Value;
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		}
		if (item.Raridade == "Épico" && item.Tipo == "Item") {
			data = "<color=#9a32cd><b>" + item.Title + "</b></color>\n\n" + item.Descricao + "\nTipo: " + item.Tipo + "\nRaridade: " + item.Raridade + "\nAtaque: " + item.Ataque + "\nDefesa: " + item.Defesa + "\nValor: " + item.Value;
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		}
		if (item.Raridade == "Lendário" && item.Tipo == "Item") {
			data = "<color=#ff7f00><b>" + item.Title + "</b></color>\n\n" + item.Descricao + "\nTipo: " + item.Tipo +  "\nRaridade: " + item.Raridade + "\nAtaque: " + item.Ataque + "\nDefesa: " + item.Defesa + "\nValor: " + item.Value;
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		}
		if (item.Tipo == "Consumível") {
			data = "<color=#ffffff><b>" + item.Title + "</b></color>\n\n" + item.Descricao + "\nTipo: " + item.Tipo + "\nVida: " + item.Vida +  "\nValor: " + item.Value;
			tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		}
	}
}