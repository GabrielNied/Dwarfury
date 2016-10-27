/*using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {
	public Player player;
	public GameObject alvo { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Espinhos") {
			player.health -= 1;
			StartCoroutine (Knockb (0.1f, 100, transform.position));
		}
	}

	public void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Espinhos") {
			player.health -= 1;

			if (player.transform.position.x >= alvo.transform.position.x) {
				StartCoroutine (Knockb (0.1f, 100, transform.position));
			}

			if (player.transform.position.x <= alvo.transform.position.x) {
				StartCoroutine (Knockb (0.1f, -100, transform.position));
			}
		}
	}
	public IEnumerator Knockb(float knockDur, float knockbackPwr, Vector3 knockbackDir)
	{

		float timer = 0;

		while (knockDur > timer)
		{

			timer += Time.deltaTime;

			this.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (knockbackDir.x * knockbackPwr, knockbackDir.y * knockbackPwr, transform.position.z));
		}

		yield return 0;

	}
}
*/