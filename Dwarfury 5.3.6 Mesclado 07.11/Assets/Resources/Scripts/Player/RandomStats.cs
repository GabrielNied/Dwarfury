using UnityEngine;
using System.Collections;

public class RandomStats : MonoBehaviour {
	public int baseatk;
	public int basedef;
	public int basehealth;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevel == 2) {
			randomStats ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void randomStats()
	{
		baseatk = 3;
		basedef = 3;
		basehealth = 5;
		while (baseatk + basedef + basehealth < 16)
		{
			int choice = Random.Range(0, 4); //random entre 0 e 3
			switch (choice)
			{
			case 0:
				if (baseatk < 6)
					baseatk++;
				break;
			case 1:
				if (basedef < 6)
					basedef++;
				break;
			default:
			case 2:
				if (basehealth < 8)
					basehealth++;
				break;

			}
		}
	}
}
