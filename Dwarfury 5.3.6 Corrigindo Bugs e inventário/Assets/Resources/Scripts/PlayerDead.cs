using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour
{

    public Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
