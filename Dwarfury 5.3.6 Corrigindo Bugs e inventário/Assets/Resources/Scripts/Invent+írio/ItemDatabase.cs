using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;

	void Start()
	{
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase();
	}

	public Item FetchItemByID(int id)
	{
		for (int i = 0; i < database.Count; i++)

			if (database[i].ID == id)
				return database[i];
		return null;
	}

	void ConstructItemDatabase()
	{
		for (int i = 0; i < itemData.Count; i++)
		{
			database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],
				(int)itemData[i]["stats"]["ataque"], (int)itemData[i]["stats"]["defesa"], (int)itemData[i]["stats"]["vida"], itemData[i]["descricao"].ToString(),
				(bool)itemData[i]["estacavel"], itemData[i]["raridade"].ToString(), itemData[i]["tipo"].ToString(), itemData[i]["slug"].ToString()));
		}
	}
}

public class Item
{
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }
	public int Ataque { get; set; }
	public int Defesa { get; set; }
	public int Vida { get; set; }
	public string Descricao { get; set; }
	public bool Estacavel { get; set; }
	public string Raridade { get; set; }
	public string Tipo { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; }

	public Item(int id, string title, int value, int ataque, int defesa, int vida, string descricao, bool estacavel, string raridade, string tipo, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Ataque = ataque;
		this.Defesa = defesa;
		this.Vida = vida;
		this.Descricao = descricao;
		this.Estacavel = estacavel;
		this.Raridade = raridade;
		this.Tipo = tipo;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
	}

	public Item()
	{
		this.ID = -1;
	}
}