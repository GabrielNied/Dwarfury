using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillManager : MonoBehaviour
{

    public GameObject SkillMenu;
    public Player player;

    public bool paused = false;
    public int ataque = 0;
    public int defesa = 0;
    public int vida = 0;


    public int ofensivo = 0;
    public int defensivo = 0;
    public int utilidade = 0;

    public Text Pontos;
    public Text Ofensivo;
    public Text Defensivo;
    public Text Utilidade;
    public Text Ataqueinfo;
    public Text Defesainfo;
    public Text Vidainfo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            paused = !paused;
        }

        if (paused)
        {
            SkillMenu.SetActive(true);
        }

        if (!paused)
        {
            SkillMenu.SetActive(false);
        }
        Pontos.text = "Pontos " + player.skillpoint;
        Ofensivo.text = "Ofensivo " + ofensivo;
        Defensivo.text = "Defensivo " + defensivo;
        Utilidade.text = "Utilidade " + utilidade;
        Ataqueinfo.text = ataque + "/5 ";
        Defesainfo.text = defesa + "/5 ";
        Vidainfo.text = vida + "/5 ";

        if (ataque == 5)
        {
            Ataqueinfo.color = Color.red;
        }
        else
        {
            Ataqueinfo.color = new Color32(50, 50, 50, 255);
        }

        if (defesa == 5)
        {
            Defesainfo.color = Color.red;
        }
        else
        {
            Defesainfo.color = new Color32(50, 50, 50, 255);
        }

        if (utilidade == 5)
        {
            Vidainfo.color = Color.red;
        }
        else
        {
            Vidainfo.color = new Color32(50, 50, 50, 255);
        }

    }

    public void Ataque()
    {
        if (ataque > 0 && ataque <= 5 && Input.GetMouseButton(1))
        {
            player.atk -= 1;
            ofensivo -= 1;
            player.skillpoint += 1;
            ataque -= 1;
        }
        if (ataque >= 0 && ataque < 5 && player.skillpoint >= 1 && Input.GetMouseButton(0))
        {
            player.atk += 1;
            ofensivo += 1;
            player.skillpoint -= 1;
            ataque += 1;
        }
    }

    public void Defesa()
    {
        if (defesa > 0 && defesa <= 5 && Input.GetMouseButton(1))
        {
            player.def -= 1;
            defensivo -= 1;
            player.skillpoint += 1;
            defesa -= 1;
        }
        if (defesa >= 0 && defesa < 5 && player.skillpoint >= 1 && Input.GetMouseButton(0))
        {
            player.def += 1;
            defensivo += 1;
            player.skillpoint -= 1;
            defesa += 1;
        }
    }

    public void Vida()
    {
        if (vida > 0 && vida <= 5 && Input.GetMouseButton(1))
        {
            player.health -= 1;
            player.maxhealth -= 1;
            utilidade -= 1;
            player.skillpoint += 1;
            vida -= 1;
        }
        if (vida >= 0 && vida < 5 && player.skillpoint >= 1 && Input.GetMouseButton(0))
        {
            player.health += 1;
            player.maxhealth += 1;
            utilidade += 1;
            player.skillpoint -= 1;
            vida += 1;
        }
    }
}
