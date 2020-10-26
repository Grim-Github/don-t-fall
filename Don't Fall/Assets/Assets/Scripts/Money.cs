using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI moneyUI = null;
	[SerializeField] private AudioClip moneyUp = null;
	[SerializeField] private AudioClip moneyDown = null;
	public static int moneyCount = 0;
	public AudioSource audioSource;

	private void Awake()
	{
		moneyCount = PlayerPrefs.GetInt("money");
		if (moneyUI != null)
		{
			UpdateUI();
		}

		Debug.Log(moneyCount);
	}

	public void IncreaseMoney(int value)
	{
		moneyCount += value;
		audioSource.PlayOneShot(moneyUp);
		if (moneyUI != null)
		{
			UpdateUI();
		}
	}	

	public void DecreaseMoney(int value)
	{
		moneyCount -= value;
		audioSource.PlayOneShot(moneyDown);
		if (moneyUI != null)
		{
			UpdateUI();
		}
	}

	public void UpdateUI()
	{
		if (moneyUI != null)
		{
			moneyUI.text = moneyCount.ToString();
		}
	}
}
