using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour {

	public bool quest = false;
	public int kills = 0;

	public bool questCompleta = false;

	public int posicao = 1;
	public int opcoes = 2;

	private GameObject questTextObject, selecao, questPanel, questAtivaObject;
	private Text questText, rewardText, aceitarText, recusarText, questAtiva;
	private ScoreManager scoreManager;
	private Player player;
	public static QuestManager Instance;

	public GameObject questTextUI;

	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();
	}

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

	void Update () {
		if (questCompleta) {
			questTextUI.GetComponent<Animation> ().Play ("QuestText");
			questCompleta = false;
		}
		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Vila")) {
			questPanel = GameObject.Find("PlayerUI/QuestPanel");
			questTextObject = GameObject.Find("PlayerUI/QuestPanel/QuestText");
			selecao = GameObject.Find("PlayerUI/QuestPanel/Selecao");
			questText = GameObject.Find("PlayerUI/QuestPanel/QuestText").GetComponent<Text>();
			rewardText = GameObject.Find("PlayerUI/QuestPanel/RewardText").GetComponent<Text>();
			aceitarText = GameObject.Find("PlayerUI/QuestPanel/AceitarText").GetComponent<Text>();
			recusarText = GameObject.Find("PlayerUI/QuestPanel/RecusarText").GetComponent<Text>();
			questAtiva = GameObject.Find("PlayerUI/QuestAtiva").GetComponent<Text>();
			questAtivaObject = GameObject.Find("PlayerUI/QuestAtiva");
			player = FindObjectOfType<Player> ();
		}

		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dwarfury")) {
			questAtiva = GameObject.Find("PlayerUI/QuestAtiva").GetComponent<Text>();
			questAtivaObject = GameObject.Find("PlayerUI/QuestAtiva");
			questTextUI = GameObject.Find("PlayerUI/QuestText");
			player = FindObjectOfType<Player> ();
		}

		if (questPanel) {
			
			if (posicao == 1) {
				selecao.transform.localPosition = new Vector3 (-79, -113, 0);
				aceitarText.GetComponent<Text> ().color = new Color (1, 1, 0);
				recusarText.GetComponent<Text> ().color = new Color (0.2F, 0.2F, 0.2F);
			}
			if (posicao == 2) {
				selecao.transform.localPosition = new Vector3 (79, -113, 0);
				aceitarText.GetComponent<Text> ().color = new Color (0.2f, 0.2f, 0.2f);
				recusarText.GetComponent<Text> ().color = new Color (1, 1, 0);
			}

			if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				if (posicao < opcoes) {
					posicao++;
				}
			}

			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (posicao > 1) {
					posicao--;
				}
			}

			if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Return)) {
				if (posicao == 1) {
					Debug.Log ("chamou");
					quest = true;
					kills = 0;
				} else if (posicao == 2) {
					Debug.Log ("chamou1 " +quest);
					quest = false;
					Debug.Log ("chamou2 " +quest);
				}
			}
		}
		Quests ();
	}

	public void Quests(){
		if (quest == true) {
			questAtiva.text = "Goblins " + kills;
			if (kills >= 5) {
				questAtiva.text = "";
				player.GetComponent<Player> ().gold += 5;
				player.GetComponent<Player> ().exp += 5;
				kills = 0;
				questCompleta = true;
				quest = false;
			}
		} else {
			questAtiva.text = "";
		}
		if (questPanel) {
			questText.text = "Objetivo \n Matar 5 Goblins";
			rewardText.text = "Recompensa \n 5 Gold \n 5 EXP";
		}
	}
}