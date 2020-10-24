using UnityEngine;

public class Platform : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private bool onTouchDestroy = false;
	private Gamemanager globalGameManager;
	private bool hit = false;

	private void Awake()
	{
		globalGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Bullet"))
		{
			GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
			if (onTouchDestroy == true)
			{
				if (hit == false)
				{
					Destroy(gameObject, Random.Range(1, 3));
					globalGameManager.SpawnPlatform();
					hit = true;
				}

			}

		}
	}
}
