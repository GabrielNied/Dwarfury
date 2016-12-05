using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
	public Canvas creditsCanvas;
    public Button startText;
    public Button exitText;
	public Button creditsText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
		creditsCanvas = creditsCanvas.GetComponent<Canvas> ();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
		creditsText = creditsText.GetComponent<Button>();
        quitMenu.enabled = false;
		creditsCanvas.enabled = false;
    }
	
    public void ExitPress()
    {
		Debug.Log ("Chamou");
        quitMenu.enabled = true;
        startText.enabled = false;
		creditsText.enabled = false;
        exitText.enabled = false;
    }

	public void CreditsPress()
	{
		Debug.Log ("Chamou1");
		creditsCanvas.enabled = true;

	}

	public void BackCreditsPress()
	{
		Debug.Log ("Chamou2");
		creditsCanvas.enabled = false;

	}

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
		creditsText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
		
	void Update () {
		if (quitMenu.enabled == true) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				quitMenu.enabled = false;
				startText.enabled = true;
				creditsText.enabled = true;
				exitText.enabled = true;
			}
		}

		if (creditsCanvas.enabled == true) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				creditsCanvas.enabled = false;
			}
		}
	}
}