﻿using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Killzone : MonoBehaviour
{
	[SerializeField] private GameObject losePanel = null;
	[SerializeField] private TextMeshProUGUI bestTimeText = null;
	[SerializeField] private CinemachineVirtualCamera cmc = null;
	[SerializeField] private AudioClip[] sounds = null;
	[SerializeField] private GameObject UPUI = null;
	private Player player;
	private Gamemanager gameManager;
	public bool has1UP = true;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (has1UP)
		{
			has1UP = false;
			player.playerRigidbody.AddForce(Vector2.up * 2500);
			UPUI.SetActive(false);
			player.playerAudio.PlayOneShot(sounds[1]);
		}
		else
		{
			losePanel.SetActive(true);
			Time.timeScale = 0.1f;
			cmc.m_Lens.OrthographicSize = Mathf.Lerp(cmc.m_Lens.OrthographicSize, 0.5f, Time.deltaTime * 35);
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().pitch = 0.4f;
			player.playerAudio.PlayOneShot(sounds[0]);
			gameManager.canPassTime = false;
			if (gameManager.timePassed > PlayerPrefs.GetFloat("bestTime"))
			{
				PlayerPrefs.SetFloat("bestTime", gameManager.timePassed);
			}
			bestTimeText.text = "BEST TIME: " + Mathf.Round(PlayerPrefs.GetFloat("bestTime"));
		}
	}

	public void Give1UP()
	{
		UPUI.SetActive(true);
		has1UP = true;
	}
}
