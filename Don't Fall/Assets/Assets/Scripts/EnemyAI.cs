using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] private GameObject bullet = null;
	[SerializeField] private AudioClip shootClip = null;
	[SerializeField] private float detectionRange = 5;
	[SerializeField] private Transform barrelTransform = null;
	[SerializeField] private float bulletForce = 60;
	[SerializeField] private float fireRate = 1;

	private float nextFire;
	private Player player;
	private AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(2,2) , 0);
		if(hit != null)
		{
			Destroy(gameObject);
			Debug.LogWarning("Despawning Enemy(overlapp)");
		}
	}


	private void Update()
	{
		float distance = Vector2.Distance(player.transform.position, transform.position);
		if(distance <= detectionRange)
		{
			Lookat();
			if (nextFire > 0)
			{
				nextFire -= Time.deltaTime;
			}
			else
			{
				Shoot();
				nextFire = fireRate;
			}
		}
	}

	private void Shoot()
	{
		source.PlayOneShot(shootClip);
		GameObject bullet_ = Instantiate(bullet, barrelTransform.position, Quaternion.identity);
		bullet_.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * bulletForce);
	}

	private void Lookat()
	{
		Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position);
		transform.up = Vector2.Lerp(transform.up , direction , Time.deltaTime* 2);
	}
}
