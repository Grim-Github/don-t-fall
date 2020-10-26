using BayatGames.SaveGameFree;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
	[SerializeField] private string shopName = "default";
	[SerializeField] private int price = 10;
	[SerializeField] private UnityEvent boughtEvent = null;
	[HideInInspector] public bool owned = false;
	private TextMeshProUGUI priceUI;
	private Money moneyManager;

	private void Awake()
	{
		owned = SaveGame.Load<bool>(shopName, owned);
		if (owned == true || price == 0)
		{
			Destroy(GetComponentInChildren<TextMeshProUGUI>().gameObject);
		}
		priceUI = GetComponentInChildren<TextMeshProUGUI>();
		priceUI.text = price.ToString();
		moneyManager = GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<Money>();
	}

	public void Buy()
	{
		if (Money.moneyCount >= price && owned == false && price > 0)
		{
			owned = true;
			SaveGame.Save<bool>(shopName, owned);
			Money.moneyCount -= price;
			moneyManager.UpdateUI();
			PlayerPrefs.SetInt("money", Money.moneyCount);
			Destroy(GetComponentInChildren<TextMeshProUGUI>().gameObject);
			Debug.Log("Bought Item");
		}

		if(owned == true || price == 0)
		{
			boughtEvent.Invoke();
		}
	}
}

