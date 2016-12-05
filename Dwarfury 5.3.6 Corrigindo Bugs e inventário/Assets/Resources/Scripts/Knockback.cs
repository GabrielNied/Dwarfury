using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {

	Rigidbody2D myrigidbody2d;

	public void knock(){
		myrigidbody2d.AddForce (-transform.forward * 1000, ForceMode2D.Impulse);
	}
}