using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] private bool onTouchDestroy = false;
	private Gamemanager globalGameManager;

	private void Awake()
	{
		globalGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();	
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			GetComponent<SpriteRenderer>().color = new Color(255,255,255);
			if(onTouchDestroy == true)
			{
				Destroy(gameObject, Random.Range(1, 3));
				globalGameManager.SpawnPlatform();
			}

		}
	}
}
