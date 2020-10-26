using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI timerUI = null;
	[SerializeField] private GameObject[] platform = null;
	[SerializeField] [Range(0, 50)] private int powerupsAmount = 10;
	[SerializeField] private GameObject[] powerups = null;
	[SerializeField] private GameObject[] portals = null;
	[SerializeField] private GameObject enemy = null;
	[SerializeField] [Range(0, 50)] private int enemyAmount = 5;

	public float timePassed = 0;
	public bool canPassTime = true;
	private void Awake()
	{
		Time.timeScale = 1;
		for (int i = 0; i < powerupsAmount; i++)
		{
			SpawnPowerups();
		}

		for (int i = 0; i < enemyAmount; i++)
		{
			SpawnEnemy();
		}
		SpawnPortals();
	}
	private void LateUpdate()
	{
		if(canPassTime == true)
		{
			timePassed += Time.deltaTime;
		}
		timerUI.text = timePassed.ToString("#.00");
	}

	public void SpawnPlatform()
	{
		Vector2 spawnpos = new Vector2(Random.Range(0, 100), Random.Range(0, 70));
		Instantiate(platform[Random.Range(0, platform.Length)], spawnpos, Quaternion.identity);
	}

	public void SpawnPowerups()
	{
		Vector2 spawnpos = new Vector2(Random.Range(0, 100), Random.Range(0, 70));
		Instantiate(powerups[Random.Range(0, powerups.Length)], spawnpos, Quaternion.identity);
	}

	public void SpawnEnemy()
	{
		Vector2 spawnpos = new Vector2(Random.Range(0, 100), Random.Range(0, 70));
		Instantiate(enemy, spawnpos, Quaternion.identity);
	}

	public void SpawnPortals()
	{
		for (int i = 0; i < portals.Length; i++)
		{
			if(i == 1)
			{
				Vector2 spawnpos = new Vector2(Random.Range(20, 70), 75);
				Instantiate(portals[i], spawnpos, Quaternion.identity);
			}
			else
			{
				Vector2 spawnpos = new Vector2(Random.Range(20, 70), 30);
				Instantiate(portals[i], spawnpos, Quaternion.identity);
			}
			
		}
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void startPortalCoroutine()
	{
		StartCoroutine(newPortal(Random.Range(20,100)));
	}

	public IEnumerator newPortal(float time)
	{
		yield return new WaitForSeconds(time);
		SpawnPortals();
	}
}
