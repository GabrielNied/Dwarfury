using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FalaNPC : MonoBehaviour {

	public Text fala;

	// Use this for initialization
	void Start () {
		Text fala = GameObject.Find("NPC Armas").GetComponent<Text>();
		fala.transform.position = new Vector2(1f,-1f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player") {
			fala.text = "Quer comprar algo?";
		}
	}
}
