using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour {
	private static CombatTextManager instance;

	public GameObject textPrefab;

	public RectTransform canvasTransform;

	public static CombatTextManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<CombatTextManager>();
			}
			return instance;
	}
}
	public void CreateText(Vector3 position, string text)
	{
		GameObject sct = (GameObject)Instantiate (textPrefab, position, Quaternion.identity);

		sct.transform.SetParent (canvasTransform);
		sct.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		sct.GetComponent<RectTransform> ().localPosition = new Vector3 (7.6f, 5.7f, -10f);
		sct.GetComponent<Text> ().text = text;
	}
}