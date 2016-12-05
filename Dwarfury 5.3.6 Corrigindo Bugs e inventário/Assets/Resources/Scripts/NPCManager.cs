using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour {


	public GameObject fala;
	public GameObject loja;

	public bool ativo = false;
	public bool abrirloja = false;

	void Start () {
	}
	

	void Update () {
		if (abrirloja == true) {
			if (Input.GetKeyDown (KeyCode.E)) {
				ativo = !ativo;

			}

			if (ativo) {
				loja.SetActive (true);
			}

			if (!ativo) {
				loja.SetActive (false);
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player") {
			fala.SetActive (true);
		}
	}

	public void OnTriggerStay2D(Collider2D target)
	{
		if (target.tag == "Player") {
			abrirloja = true;
		}
	}

	public void OnTriggerExit2D(Collider2D target)
	{
		if (target.tag == "Player") {
			fala.SetActive (false);
			loja.SetActive (false);
			ativo = false;
			abrirloja = false;
		}
	}
}
