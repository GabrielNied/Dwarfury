using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] HeartSprites;

    public Image HeartUI;

    public Player player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Update()
    {
 //       HeartUI.sprite = HeartSprites[player.health];
    }
}