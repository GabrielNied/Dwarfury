using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour {

	public static FadeManager Instance{ set; get; }

	public Image FadeImage;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;
	public GameObject Image;

	private void Awake(){
		Image.SetActive(true);
		Instance = this;
	}

	public void Fade(bool showing, float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing) ? 0 : 1;
		Debug.Log("Chamou");
	}

	private void Update(){
			//Fade (true, 1.25f);
			//Fade (false, 3.0f);

			
		if (!isInTransition)
			return;

		transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
		FadeImage.color = Color.Lerp (new Color (1, 1, 1, 0), Color.black, transition);

		if (transition > 1 || transition < 0){
			isInTransition = false;
		}
	}
}