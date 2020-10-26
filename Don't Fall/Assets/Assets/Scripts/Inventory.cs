using UnityEngine;
using BayatGames.SaveGameFree;

public class Inventory : MonoBehaviour
{
	[SerializeField] public Sprite[] playerSprites = null;
	[SerializeField] private int selectedSprite = 0;
	[SerializeField] private Player player = null;

	private void Awake()
	{
		selectedSprite = SaveGame.Load<int>("selectedSprite");
		if (player != null)
		{
			player.gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[selectedSprite];
		}
	}

	public void PlayerSprite(int value)
	{
		selectedSprite = value;
		shopPreview.previewImage.sprite = playerSprites[selectedSprite];
		SaveGame.Save<int>("selectedSprite", value);
	}
}
