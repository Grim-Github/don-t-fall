using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Killzone : MonoBehaviour
{
	[SerializeField] private GameObject losePanel = null;
	[SerializeField] private TextMeshProUGUI bestTimeText = null;
	[SerializeField] private CinemachineVirtualCamera cmc = null;
	[SerializeField] private AudioClip loseSound = null;
	private Player player;
	private Gamemanager gameManager;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		losePanel.SetActive(true);
		Time.timeScale = 0.1f;
		cmc.m_Lens.OrthographicSize = Mathf.Lerp(cmc.m_Lens.OrthographicSize, 0.5f, Time.deltaTime * 35);
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().pitch = 0.4f;
		player.playerAudio.PlayOneShot(loseSound);
		gameManager.canPassTime = false;
		if (gameManager.timePassed > PlayerPrefs.GetFloat("bestTime"))
		{
			PlayerPrefs.SetFloat("bestTime", gameManager.timePassed);
		}
		bestTimeText.text = "BEST TIME: " + Mathf.Round(PlayerPrefs.GetFloat("bestTime"));
	}
}
