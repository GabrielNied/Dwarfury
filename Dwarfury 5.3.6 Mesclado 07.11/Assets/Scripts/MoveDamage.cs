using UnityEngine;
using System.Collections;

public class MoveDamage : MonoBehaviour {
	//start and end position. set in start method
	private Vector3 start;
	private Vector3 end;

	//animation curves for movement along path and alpha
	public AnimationCurve acMove;
	public AnimationCurve acAlpha;

	//time to animate in seconds
	public float time = 2.0f;

	//distance to move for animation. Speed is distance/time for units per second.
	//a longer time or shorter distance will slow the movement speed down
	public float distance = 2.0f;

	//the end point is moved +/- this amount left or right at random.
	//this is just so the text moves upwards at an angle and not always right on top of each other
	public float xOffset = 0.5f;

	void Start () {
		//starting position
		start = transform.position;
		//random end position above starting position
		end = start + new Vector3(Random.Range(-xOffset, xOffset), distance, 0.5f);

		//start the animation
		StartCoroutine(Animate(start, end));
	}

	IEnumerator Animate(Vector3 pos1, Vector3 pos2) {
		//start our timer
		float timer = 0.0f;
		//stores the values of our animation curve evaluation
		float evalMove = 0.0f;
		float evalAlpha = 0.0f;

		//the textmesh to change the color
		TextMesh textMesh = GetComponent<TextMesh>();

		//while we haven't hit our timeout
		while (timer <= time) {
			//get the next values from the animation curve
			evalMove = acMove.Evaluate(timer/time);
			evalAlpha = 1f-acAlpha.Evaluate(timer/time);

			//lerp along our path from start to end position
			transform.position = Vector3.Lerp (pos1, pos2, evalMove);

			//get the current color of the text
			Color color = textMesh.color;
			//set the alpha value for fade out
			color.a = evalAlpha;
			//set textmesh color to new color
			textMesh.color = color;

			//add to the timer
			timer += Time.deltaTime;
			//wait until next frame
			yield return null;
		}
		//time is up, destroy self
		Destroy(gameObject);
	}
}