using UnityEngine;
using BayatGames.SaveGameFree;

public class Inventory : MonoBehaviour
{
	[Header("Global Database")]
	[SerializeField] public Sprite[] playerSprites = null;
	[SerializeField] public Color[] playerColors = null;
	[Header("Player Settings")]
	[SerializeField] public int selectedSprite = 0;
	[SerializeField] public int selectedColor = 0;
	[Header("Settings")]
	[SerializeField] private Player player = null;

	private void Awake()
	{
		 if(SaveGame.Exists("selectedSprite"))
		{
			selectedSprite = SaveGame.Load<int>("selectedSprite");
		}
		 if(SaveGame.Exists("selectedColor"))
		{
			selectedColor = SaveGame.Load<int>("selectedColor");
		}
		if (player != null)
		{
			player.gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[selectedSprite];
			player.gameObject.GetComponent<SpriteRenderer>().color = playerColors[selectedColor];
		}
	}

	public void PlayerSprite(int value)
	{
		selectedSprite = value;
		shopPreview.previewImage.sprite = playerSprites[selectedSprite];
		SaveGame.Save<int>("selectedSprite", value);
	}

	public void PlayerColor(int value)
	{
		selectedColor = value;
		shopPreview.previewImage.color = playerColors[selectedColor];
		SaveGame.Save<int>("selectedColor" , value);
	}
}
