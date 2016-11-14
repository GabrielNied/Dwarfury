using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float destroyTime = 0.3f;

	void Start () {
		Destroy (this.gameObject, destroyTime);
	}
	

	void Update () {
	
	}
}
