using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI timerUI = null;
	[SerializeField] private GameObject[] platform = null;
	[SerializeField] [Range(0, 50)] private int powerupsAmount = 10;
	[SerializeField] private GameObject[] powerups = null;
	public float timePassed = 0;
	public bool canPassTime = true;
	private void Awake()
	{
		for (int i = 0; i < powerupsAmount; i++)
		{
			SpawnPowerups();
		}
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

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
