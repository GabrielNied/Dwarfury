using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	public GameObject Bloco1;
	public GameObject Bloco2;
	public GameObject Bloco3;

	public bool bloco1 = false;
	public bool bloco2 = false;
	public bool bloco3 = false;
	// Use this for initialization
	void Start () {
			int choice = Random.Range(0, 3); //random entre 0 e 3
		Debug.Log ("Bloco: "+choice);
			switch (choice)
			{
			case 0:
				Bloco1.SetActive (true);
				bloco1 = true;
				break;
			case 1:
				Bloco2.SetActive (true);
				bloco2 = true;
				break;
			case 2:
				Bloco3.SetActive (true);
				bloco3 = true;
				break;

			}
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
