using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCQuest : MonoBehaviour
{
	public GameObject fala;
	public GameObject quest;

	public bool ativo = false;
	public bool painel = false;

	private GameObject player;
	void Start()
	{
		player = GameObject.Find("Player");
	}

	void Update()
	{
		if (painel == true)
		{
			if (Input.GetKeyUp(KeyCode.E))
			{
				ativo = !ativo;
				player.GetComponent<Player> ().trancaMovimento = !player.GetComponent<Player> ().trancaMovimento;
			}

			if (ativo)
			{
				quest.SetActive(true);
			}

			if (!ativo)
			{
				quest.SetActive(false);
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player")
		{
			fala.SetActive(true);
		}
	}

	public void OnTriggerStay2D(Collider2D target)
	{
		if (target.tag == "Player")
		{
			painel = true;
		}
	}

	public void OnTriggerExit2D(Collider2D target)
	{
		if (target.tag == "Player")
		{
			fala.SetActive(false);
			quest.SetActive(false);
			ativo = false;
			painel = false;
		}
	}
}
