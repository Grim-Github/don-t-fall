using UnityEngine;
using Cinemachine;

public class Killzone : MonoBehaviour
{
	[SerializeField] private GameObject losePanel = null;
	[SerializeField] private CinemachineVirtualCamera cmc = null;
	[SerializeField] private AudioClip loseSound = null;
	private Player player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		losePanel.SetActive(true);
		Time.timeScale = 0.1f;
		cmc.m_Lens.OrthographicSize = Mathf.Lerp(cmc.m_Lens.OrthographicSize , 0.5f , Time.deltaTime * 25);
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().pitch = 0.4f;
		player.playerAudio.PlayOneShot(loseSound);
	}
}
