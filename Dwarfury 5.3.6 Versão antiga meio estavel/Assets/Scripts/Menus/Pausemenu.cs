using UnityEngine;
using System.Collections;

public class Pausemenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

        void Start()
    {
        PauseUI.SetActive(false);
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
            Time.timeScale = 1;
        }

    }

    public void Back()
    {
        paused = false;
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
