using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] [Range(0, 100)] int spawnChange = 10;
	private Money moneyManager;

	private void Awake()
	{
		if (spawnChange > Random.Range(0, 101))
		{
			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}

		moneyManager = GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<Money>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		moneyManager.IncreaseMoney(1);
		Destroy(gameObject);
	}
}
