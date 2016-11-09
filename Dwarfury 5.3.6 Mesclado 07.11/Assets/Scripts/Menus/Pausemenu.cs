using UnityEngine;
using System.Collections;

public class Pausemenu : MonoBehaviour {

    public GameObject PauseUI;
	public GameObject SaveMenu;
	public GameObject LoadMenu;
	public Save save;
    public bool paused = false;

        void Start()
    {
        PauseUI.SetActive(false);
		SaveMenu.SetActive(false);
		LoadMenu.SetActive(false);
    }

        void Update()
    {
            if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

    if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

    if (!paused)
        {
            PauseUI.SetActive(false);
			SaveMenu.SetActive (false);
			LoadMenu.SetActive (false);
            Time.timeScale = 1;
        }

    }

    public void Back()
    {
        paused = false;
    }

	public void VoltarSave(){
		PauseUI.SetActive (true);
		SaveMenu.SetActive (false);
		LoadMenu.SetActive (false);
		save.textoinfosave.text = null;
	}

	public void VoltarLoad(){
		PauseUI.SetActive (true);
		SaveMenu.SetActive (false);
		LoadMenu.SetActive (false);
		save.textoinfoload.text = null;
	}

	public void Save(){
		PauseUI.SetActive (false);
		SaveMenu.SetActive (true);
		LoadMenu.SetActive (false);
	}

	public void Load(){
		PauseUI.SetActive (false);
		SaveMenu.SetActive (false);
		LoadMenu.SetActive (true);
	}

   public void MainMenu() 
   {
        Application.LoadLevel(0); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
