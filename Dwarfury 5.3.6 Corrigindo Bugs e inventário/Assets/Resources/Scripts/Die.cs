using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            player.killPlayer();
        }
    }

}
