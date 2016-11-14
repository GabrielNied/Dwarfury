using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public FadeManager fM;
	public Player player;
	public string levelToLoad;
	public Pausemenu pM;


	public void ChangeToScene (){ 
		pM.paused = false;
		fM.Fade (true, 3.0f);
		PlayerPrefs.SetInt ("Vida1", player.health);
		PlayerPrefs.SetInt ("Vida2", player.maxhealth);
		PlayerPrefs.SetInt ("Atq1", player.atk);
		PlayerPrefs.SetInt ("Def1", player.def);
		StartCoroutine (Wait(3.0f));
	
	}

	IEnumerator Wait(float waitTime){
		yield return new WaitForSeconds (waitTime);
		Application.LoadLevel(levelToLoad);
	}

}
