using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour {

	public Sprite sprite2;
	public GameObject particle;
	private SpriteRenderer spriteRenderer; 

	public bool foiAberto = false;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		if (CompareTag("BauAberto") && !foiAberto)
		{
			ChangeTheDamnSprite ();
			foiAberto = true;
		}
	}

	void ChangeTheDamnSprite ()
	{		
		spriteRenderer.sprite = sprite2;
		particle.SetActive (false);
	}
}