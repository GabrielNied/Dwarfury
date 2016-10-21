using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    private bool playerInZone;

    public string levelToLoad;
	public Player player;
	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
			PlayerPrefs.SetInt ("Vida1", player.health);
			PlayerPrefs.SetInt ("Vida2", player.maxhealth);
			PlayerPrefs.SetInt ("Atq1", player.atk);
			PlayerPrefs.SetInt ("Def1", player.def);
            Application.LoadLevel(levelToLoad);

        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }

}
