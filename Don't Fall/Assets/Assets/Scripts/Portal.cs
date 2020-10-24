using UnityEngine;

public class Portal : MonoBehaviour
{
	public enum portalType { Sender, Receiver };
	public portalType type;
	[SerializeField] private AudioClip teleportClip = null;
	[SerializeField] private bool destroyAfterUse = true;

	private Player player;
	private Gamemanager gamemanager;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			Teleport();
		}
	}

	private void Teleport()
	{
		if (type == portalType.Sender)
		{
			Portal foundPortal = GameObject.FindObjectOfType<Portal>();

			if (foundPortal.type == portalType.Receiver)
			{
				player.transform.position = foundPortal.transform.position;
				player.UnGrapple();
				player.playerAudio.PlayOneShot(teleportClip);
				if(destroyAfterUse == true)
				{
					gamemanager.startPortalCoroutine();
					Destroy(gameObject);
					Destroy(foundPortal.gameObject);
				}
			}
		}
	}
}
