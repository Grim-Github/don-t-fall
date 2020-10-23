using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUP : MonoBehaviour
{
	[SerializeField] private UnityEvent OnPickUp = null;
	[SerializeField] private AudioClip pickupSound = null;
	private Player player;
	private Killzone killZone;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		killZone = GameObject.FindGameObjectWithTag("KillZone").GetComponent<Killzone>();
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

	public void OneLife()
	{
		if(killZone.has1UP == false)
		{
			killZone.Give1UP();
		}
		else
		{
			player.grapplesLeft += 7;
		}
	}
}
