using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public GameObject Obj;

	public Camera mCamera;
	private RectTransform rt;

	void Start ()
	{
		rt = GetComponent<RectTransform>();
	}

	void Update ()
	{
		if (Obj != null)
		{
			Vector2 pos = RectTransformUtility.WorldToScreenPoint(mCamera, Obj.transform.position);
			rt.position = pos;
		}
	}
}