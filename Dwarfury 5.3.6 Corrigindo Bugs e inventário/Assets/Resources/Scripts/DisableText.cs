using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableText : MonoBehaviour
{

	public GameObject texto;
	private Animation animation;

    void Start()
    {

    }

    public void Desativa()
    {
		animation.Stop ();
    }

    void Update()
    {

    }
}
