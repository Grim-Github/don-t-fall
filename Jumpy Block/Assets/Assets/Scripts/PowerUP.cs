using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUP : MonoBehaviour
{
	[SerializeField] private UnityEvent OnPickUp = null;
	[SerializeField] private AudioClip pickupSound = null;
	private Player player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnPickUp.Invoke();
		player.playerAudio.PlayOneShot(pickupSound);
		player.UpdateStats();
		Destroy(gameObject);
	}

	public void GrappleUP()
	{
		player.grapplesLeft += 5;
	}
}
