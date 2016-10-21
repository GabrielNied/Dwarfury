using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour {

	private PolygonCollider2D playerCollider;

	[SerializeField]
	private BoxCollider2D platformCollider;

	[SerializeField]
	private BoxCollider2D plataformTrigger;

	// Use this for initialization
	void Start () {
	
		playerCollider = GameObject.Find ("Player").GetComponent<PolygonCollider2D> ();
		Physics2D.IgnoreCollision (platformCollider, plataformTrigger, true);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			Physics2D.IgnoreCollision (platformCollider, playerCollider, true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			Physics2D.IgnoreCollision (platformCollider, playerCollider, false);
		}
	}
}
