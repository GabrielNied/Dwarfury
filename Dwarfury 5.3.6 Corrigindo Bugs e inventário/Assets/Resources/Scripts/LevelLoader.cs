using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    private bool playerInZone;

    public string levelToLoad;
	public Player player;
	public FadeManager fM;

	public GameObject botaoE;

	void Start () {
        playerInZone = false;
	}
	

	void Update () {
		
		if(Input.GetButtonDown ("TrocarFase") && playerInZone)
        {
			fM.Fade (true, 3.0f);
			PlayerPrefs.SetInt ("Vida1", player.health);
			PlayerPrefs.SetInt ("Vida2", player.maxhealth);
			PlayerPrefs.SetInt ("Atq1", player.atk);
			PlayerPrefs.SetInt ("Def1", player.def);
			PlayerPrefs.SetInt("Gold1", player.gold);
			PlayerPrefs.SetInt("Level1", player.level);
			PlayerPrefs.SetInt("Exp1", player.exp);
			StartCoroutine (Wait(3.0f));
        }
	}

	IEnumerator Wait(float waitTime){
		yield return new WaitForSeconds (waitTime);
		Application.LoadLevel(levelToLoad);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = true;
			botaoE.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
			botaoE.SetActive(false);
        }
    }

}
