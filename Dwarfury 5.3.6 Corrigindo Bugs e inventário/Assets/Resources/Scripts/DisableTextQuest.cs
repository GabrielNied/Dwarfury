using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTextQuest : MonoBehaviour
{

	public GameObject texto;
	private Animation animation;

    void Start()
    {

    }

    public void DesativaQuest()
    {
		animation.Stop ();
    }

    void Update()
    {

    }
}
