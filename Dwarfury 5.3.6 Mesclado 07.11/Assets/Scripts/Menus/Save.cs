using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Save : MonoBehaviour{

	public Player player;
	public Text textoinfosave;
	public Text textoinfoload;
	public GameObject SaveMenu;
	public GameObject LoadMenu;
	private int playedTime;
	private string theDate;
	private string theTime;

	void Start(){
		SaveMenu.SetActive (true);
		for (int slot = 1; slot <= 3; slot++) {
			BinaryFormatter bf = new BinaryFormatter ();
			if (File.Exists (Application.persistentDataPath + "/save" + slot + ".dat")) {
				FileStream file = File.Open (Application.persistentDataPath + "/save" + slot + ".dat", FileMode.Open);
				PlayerClass newData = (PlayerClass)bf.Deserialize (file);
				file.Close ();

				var textoBotaosave = GameObject.Find ("SaveSlot" + slot).transform.GetChild (0).GetComponent<Text> ();
				textoBotaosave.text = PlayerPrefs.GetString("tempo") + " " + PlayerPrefs.GetString("hora");
			}
		}
		SaveMenu.SetActive (false);
	
		LoadMenu.SetActive(true);
		for (int slot = 1; slot <= 3; slot++) {
			BinaryFormatter bf = new BinaryFormatter();
			if (File.Exists(Application.persistentDataPath + "/save" + slot + ".dat")) {
				FileStream file = File.Open(Application.persistentDataPath + "/save" + slot + ".dat", FileMode.Open);
				PlayerClass newData = (PlayerClass)bf.Deserialize(file);
				file.Close();

				var textoBotaoload = GameObject.Find ("LoadSlot" + slot).transform.GetChild (0).GetComponent<Text> ();
				textoBotaoload.text = PlayerPrefs.GetString("tempo") + " " + PlayerPrefs.GetString("hora");
			}
		}
		LoadMenu.SetActive(false);
	}

	void Update(){
		theTime = System.DateTime.Now.ToString("hh:mm:ss"); 
		theDate = System.DateTime.Now.ToString("MM/dd/yyyy"); 
	//	theMonth = System.DateTime.Now.get_Month();
	//	theDay = System.DateTime.Now.get_Day();
		playedTime = System.DateTime.Now.DayOfYear;
	}

	public void Salvar(int slot){
		textoinfosave.text = "Salvando no slot " + slot;

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/save"+slot+".dat", FileMode.Create);
		PlayerClass newData = new PlayerClass();
		newData.health = player.health;
		newData.atk = player.atk;
		newData.def = player.def;
		newData.exp = player.exp;
		newData.maxhealth = player.maxhealth;
		bf.Serialize(file, newData);
		file.Close();
		Debug.Log ("Salvou  "+newData.atk+"asdas    "+player.atk);
		textoinfosave.text = "Jogo salvo no slot " + slot;

		var textoBotaosave = GameObject.Find ("SaveSlot" + slot).transform.GetChild (0).GetComponent<Text> ();
		textoBotaosave.text = "" + theDate + " " + theTime;
		PlayerPrefs.SetString ("tempo", theDate);
		PlayerPrefs.SetString ("hora", theTime);
		LoadMenu.SetActive(true);
		var textoBotaoload = GameObject.Find ("LoadSlot" + slot).transform.GetChild (0).GetComponent<Text> ();
		textoBotaoload.text = PlayerPrefs.GetString("tempo") + " " + PlayerPrefs.GetString("hora");
		LoadMenu.SetActive(false);
	}

	public void Load(int slot){

		if (File.Exists(Application.persistentDataPath + "/save"+slot+".dat")){
			textoinfoload.text = "Carregando jogo do slot " + slot;
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/save"+slot+".dat", FileMode.Open);
			PlayerClass newData = (PlayerClass)bf.Deserialize(file);
			file.Close();
			player.health = newData.health;
			player.maxhealth = newData.maxhealth;
			player.atk = newData.atk;
			player.def = newData.def;
			player.exp = newData.exp;
			Debug.Log ("Loadedi");
			textoinfoload.text = "Jogo carregado do slot " + slot;


		}
	}

	[Serializable]
	class PlayerClass{
		public int health;
		public int atk;
		public int def;
		public int maxhealth;
		public int exp;
	}
}
