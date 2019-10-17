using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int inimigosMortos = 0, goldTotal = 0, goldTotalScore,  maxLvl = 0, maxLvlScore;
	public float totalScore = 0f, totalScoreTotal, bestScoreAtual = 0f, bestScoreNew = 0f;
	public float tempoTotal = 0;
	public static ScoreManager Instance;
	public Player player;
	public GameObject inimigosMortosText, tempoTotalText, goldTotalText, maxLvlText, totalScoreText, bestScoreText;

	void Start () {
		SceneManager.sceneLoaded += OnSceneLoaded;
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

	private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
	{
		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Menus")) {
			CalcScore ();
		}
		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("tutorial")) {
			bestScoreNew = 0f;
			totalScore = 0f;
		}
	}

	void Update () {
		tempoTotal += Time.deltaTime;

		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dwarfury")) {
			player = FindObjectOfType<Player> ();
			goldTotal = player.gold;
			maxLvl = player.level;
		}
		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("tutorial")) {
			player = FindObjectOfType<Player> ();
			goldTotal += player.gold;
			maxLvl = player.level;
		}
		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Vila")) {
			player = FindObjectOfType<Player> ();
			goldTotal = player.gold;
			maxLvl = player.level;
		}
			


		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Menus")) {
			totalScoreText = GameObject.Find("ProgressCanvas/Panel/Panel/TotalScore");
			goldTotalText = GameObject.Find("ProgressCanvas/Panel/Panel/TotalGoldCollected");
			inimigosMortosText = GameObject.Find("ProgressCanvas/Panel/Panel/TotalMonstersKilled");
			bestScoreText = GameObject.Find("ProgressCanvas/Panel/Panel/BestScore");
			maxLvlText = GameObject.Find("ProgressCanvas/Panel/Panel/HighetsLevel");

			totalScoreText.GetComponent<Text>().text = "Total Score\n" + totalScoreTotal;
			goldTotalText.GetComponent<Text>().text = "Total Gold Collected\n" + goldTotalScore;
			inimigosMortosText.GetComponent<Text>().text = "Total Monsters Killed\n" + inimigosMortos;
			bestScoreText.GetComponent<Text>().text = "Best Score\n" + bestScoreAtual;
			maxLvlText.GetComponent<Text>().text = "Highest Level\n" + maxLvlScore;
		}
	}

	public void CalcScore(){
		totalScore = (inimigosMortos*0.8f) + (goldTotal*1.2f) + (maxLvl*1.4f);
		totalScoreTotal += totalScore;

		bestScoreNew = (inimigosMortos*0.8f) + (player.gold*1.2f) + (player.level*1.4f);

		if (bestScoreNew > bestScoreAtual) {
			bestScoreAtual = bestScoreNew;
		}

		goldTotalScore += goldTotal;

		if (maxLvl > maxLvlScore) {
			maxLvlScore = maxLvl;
		}
	}
}
