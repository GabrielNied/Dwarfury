using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour {


	public GameObject fala;

	void Start () {
	}
	

	void Update () {

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
			if (Input.GetKeyDown (KeyCode.E)) {

			}
		}
	}

	public void OnTriggerExit2D(Collider2D target)
	{
		if (target.tag == "Player") {
			fala.SetActive (false);
		}
	}
}
