﻿using Cinemachine;
using TMPro;
using UnityEngine;

public class Killzone : MonoBehaviour
{
	[SerializeField] private GameObject losePanel = null;
	[SerializeField] private TextMeshProUGUI bestTimeText = null;
	[SerializeField] private CinemachineVirtualCamera cmc = null;
	[SerializeField] private AudioClip[] sounds = null;
	[SerializeField] private GameObject UPUI = null;
	private Player player;
	private Gamemanager gameManager;
	private Money moneyManager;
	public bool has1UP = true;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
		moneyManager = GameObject.FindGameObjectWithTag("MoneyManager").GetComponent<Money>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			if (has1UP)
			{
				Take1UP(true);
			}
			else
			{
				if(player.canMove == true)
				{
					Die();
				}
			}
		}
	}

	public void Die()
	{
		losePanel.SetActive(true);
		Time.timeScale = 0.1f;
		cmc.m_Lens.OrthographicSize = Mathf.Lerp(cmc.m_Lens.OrthographicSize, 0.5f, Time.deltaTime * 15);
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().pitch = 0.4f;
		player.playerAudio.PlayOneShot(sounds[0]);
		player.GetComponent<SpriteRenderer>().color = Color.black;
		player.canMove = false;
		gameManager.canPassTime = false;
		moneyManager.IncreaseMoney((int)(gameManager.timePassed / 100));
		PlayerPrefs.SetInt("money", Money.moneyCount);
		if (gameManager.timePassed > PlayerPrefs.GetFloat("bestTime"))
		{
			PlayerPrefs.SetFloat("bestTime", gameManager.timePassed);
		}
		bestTimeText.text = "BEST TIME: " + Mathf.Round(PlayerPrefs.GetFloat("bestTime"));
	}

	public void Give1UP()
	{
		UPUI.SetActive(true);
		has1UP = true;
	}

	public void Take1UP(bool launch)
	{
		has1UP = false;
		if (launch)
		{
			player.playerRigidbody.AddForce(Vector2.up * 8600);
		}
		UPUI.SetActive(false);
		player.playerAudio.PlayOneShot(sounds[1]);
	}

}
