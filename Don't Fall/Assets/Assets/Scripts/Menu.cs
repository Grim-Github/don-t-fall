using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI versionUI = null;

	private void Awake()
	{
		versionUI.text = Application.version;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
