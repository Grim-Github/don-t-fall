using UnityEngine;
using UnityEngine.UI;

public class shopPreview : MonoBehaviour
{
	public static Image previewImage = null;
	private Inventory inventoryManager = null;

	private void Awake()
	{
		previewImage = GetComponent<Image>();
		inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
		previewImage.color = inventoryManager.playerColors[inventoryManager.selectedColor];
		previewImage.sprite = inventoryManager.playerSprites[inventoryManager.selectedSprite];
	}
}
