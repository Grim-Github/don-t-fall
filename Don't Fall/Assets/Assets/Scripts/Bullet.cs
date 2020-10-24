using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private ParticleSystem destructionParticle = null;
	private Killzone killZone;

	private void Awake()
	{
		Destroy(gameObject, 20);
		killZone = GameObject.FindGameObjectWithTag("KillZone").GetComponent<Killzone>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			if (killZone.has1UP)
			{
				killZone.Take1UP(false);
			}
			else
			{
				killZone.Die();
			}
			Destroy(gameObject);
		}
		else
		{
			ParticleSystem particle = Instantiate(destructionParticle, transform.position, Quaternion.identity);
			particle.startColor = collision.transform.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
		}
	}
}
