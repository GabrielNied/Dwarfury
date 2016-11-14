using UnityEngine;
using System.Collections;

public class SaveStats : MonoBehaviour {
	private Player player;
	private RandomStats randomStats;

	public int atk;
	public int def;
	public int health;

	void Start () {
		Recalcular ();
	}

	void Update () {
	
	}

	public void Recalcular(){
		atk = randomStats.baseatk;
		def = randomStats.basedef;
		health = randomStats.basehealth;
	}
}
