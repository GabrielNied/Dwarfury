using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Collections.Generic;   

public class AchivManager : MonoBehaviour {

	public bool tocou1,tocou2,tocou3 = false;
	public Text achivText;

	public GameObject achivTextObject, achivTextPrefab;
	private ScoreManager scoreManager;
	public static AchivManager Instance;

	public List<AchivText> meus = new List<AchivText>();

	void Awake()
	{
		if(Instance){
			DestroyImmediate(gameObject);
		}else
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}

	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();

		SceneManager.sceneLoaded += OnSceneLoaded;

		meus.Add (new AchivText (0, "First Blood" , false));
		meus.Add (new AchivText (1, "Killing Spree" , false));
		meus.Add (new AchivText (2, "Rampage" , false));
		CheckAchivs ();
	}

	private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
	{
		CheckAchivs ();
	}



	void Update () {
		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dwarfury")) {
			achivTextObject = GameObject.Find("PlayerUI/AchivText");
			achivText = GameObject.Find("PlayerUI/AchivText").GetComponent<Text>();
		}
		Achivs ();
			//CheckAchivs ();
	}

	public void CheckAchivs(){
		//if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Menus")) {
		//if (tocou1) {

		//go.transform.position = 
		//	}
		//}

		//string a  = PlayerPrefs.GetString("ACHI");

		//0/1/12/18

		//string meuac[];


		//for(int i = 0; i < 10; i++){
			for (int i = 0; i < meus.Count; i++) {
				//AchivText novo = new AchivText (0,"teste" + i, false);
				//meus.Add (novo);
				GameObject go = Instantiate (achivTextPrefab, achivTextPrefab.transform.position, Quaternion.identity) as GameObject; 
				go.transform.parent = GameObject.Find ("AchivCanvas/Panel/Panel/Scroll View/Viewport/Content/corrinha").transform; 
				go.GetComponent<Text> ().text = meus [i].nome;//novo.nome;
				go.transform.localPosition = new Vector3 (0, -100 * i, 0);
				go.gameObject.SetActive (meus [i].isActived);
			}
		}


	public void Achivs(){
		if (scoreManager.inimigosMortos == 1 && !tocou1) {
				achivText.text = ("First Blood");
				achivTextObject.GetComponent<Animation> ().Play ("AchivText");
				tocou1 = true;
			meus [0].isActived = true;
			Debug.Log("meus 0: " + meus[0].isActived);
		}

		if (scoreManager.inimigosMortos == 2 && !tocou2) {
			if (!achivTextObject.GetComponent<Animation> ().isPlaying) {
				achivText.text = ("Killing Spree");
				achivTextObject.GetComponent<Animation> ().Play ("AchivText");
				tocou2 = true;
				meus [1].isActived = true;
			}
		}

		if (scoreManager.inimigosMortos == 3 && !tocou3) {
			if (!achivTextObject.GetComponent<Animation> ().isPlaying) {
				achivText.text = ("Rampage");
				achivTextObject.GetComponent<Animation> ().Play ("AchivText");
				tocou3 = true;
				meus [2].isActived = true;
			}
		}
	}
}
