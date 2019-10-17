using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivText {

	public int id = 0;
	public string nome = "";

	public bool isActived = false;

	public AchivText (int id, string nome , bool isActived){
		this.id = id;
		this.nome = nome;
		this.isActived = isActived;
	}

}