using UnityEngine;
using System.Collections;

public class CriaTexto : MonoBehaviour {

	void Start() {
		GameObject go = new GameObject();
		go.AddComponent<GUIText>();
		go.transform.position = new Vector3(0.5f,0.5f,0.0f);
		go.GetComponent<GUIText>().text = "Hello World";
	}
}