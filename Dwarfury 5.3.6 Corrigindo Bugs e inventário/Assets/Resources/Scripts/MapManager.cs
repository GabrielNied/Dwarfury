using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	public Player player;

	public GameObject Bloco11;
	public GameObject Bloco12;
	public GameObject Bloco13;
	public GameObject Bloco21;
	public GameObject Bloco22;
	public GameObject Bloco23;
	public GameObject Bloco24;
	public GameObject Bloco31;
	public GameObject Bloco32;
	public GameObject Bloco33;

	void Awake () {
		int choice = Random.Range(0, 3); //random entre 0 e 3
		switch (choice)
		{
		case 0:
			Bloco11.SetActive (true);
			player.transform.position = new Vector2 (6.51f, -1.51f);
			break;
		case 1:
			Bloco12.SetActive (true);
			player.transform.position = new Vector2 (6.51f, 2.77f);
			break;
			default:
		case 2:
			Bloco13.SetActive (true);
			player.transform.position = new Vector2 (6.51f, 7.476456f);
			break;

		}

		int choice2 = Random.Range(0, 4); //random entre 0 e 3
		switch (choice2)
		{
		case 0:
			Bloco21.SetActive (true);
			break;
		case 1:
			Bloco22.SetActive (true);
			break;
		case 2:
			Bloco23.SetActive (true);
			break;
			default:
		case 3:
			Bloco24.SetActive (true);
			break;
		}
			
		int choice3 = Random.Range(0, 3); //random entre 0 e 3
		switch (choice3)
		{
		case 0:
			Bloco31.SetActive (true);
			break;
		case 1:
			Bloco32.SetActive (true);
			break;
			default:
		case 2:
			Bloco33.SetActive (true);
			break;
		}
	}

	void Update () {
	
	}
}
