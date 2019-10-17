using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
	public Canvas creditsCanvas;
	public Canvas achievementCanvas;
	public Canvas progressCanvas;
    public Button startText;
    public Button exitText;
	public Button creditsText;

	public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
		creditsCanvas = creditsCanvas.GetComponent<Canvas> ();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
		creditsText = creditsText.GetComponent<Button>();
        quitMenu.enabled = false;
		creditsCanvas.enabled = false;
		achievementCanvas.enabled = false;
		progressCanvas.enabled = false;
    }
	
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
		creditsText.enabled = false;
        exitText.enabled = false;
    }

	public void CreditsPress()
	{
		creditsCanvas.enabled = true;

	}

	public void BackCreditsPress()
	{
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
		scoreManager.bestScoreNew = 0f;
        SceneManager.LoadScene(1);
		PlayerPrefs.SetInt("Gold1", 0);
		PlayerPrefs.SetInt("Level1", 1);
		PlayerPrefs.SetInt ("Exp1", 0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

	public void Achievement()
	{
		achievementCanvas.enabled = true;

	}

	public void BackAchievement()
	{
		achievementCanvas.enabled = false;

	}

	public void Progress()
	{
		progressCanvas.enabled = true;

	}

	public void BackProgress()
	{
		progressCanvas.enabled = false;

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