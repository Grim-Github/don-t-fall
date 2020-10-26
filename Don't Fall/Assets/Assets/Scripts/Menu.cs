using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI versionUI = null;

	private static bool once = false;

	private void Awake()
	{
		if(once == false && versionUI != null)
		{
			versionUI.text = Application.version;
			once = true;
		}

	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void AudioVolume()
	{
		Slider audioslider = GetComponent<Slider>();
		AudioListener.volume = audioslider.value;
	}

	public void ChangeResolutionType()
	{
		TMP_Dropdown TMPDD = GetComponent<TMP_Dropdown>();
		if(TMPDD.value == 0)
		{
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		}
		else if (TMPDD.value == 1)
		{
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
		else if (TMPDD.value == 2)
		{
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
		}
	}

	public void ChangeResolution()
	{
		TMP_Dropdown TMPDD = GetComponent<TMP_Dropdown>();
		if (TMPDD.value == 0)
		{
			Screen.SetResolution(1920,1080 , Screen.fullScreen);
		}
		else if (TMPDD.value == 1)
		{
			Screen.SetResolution(1600, 900, Screen.fullScreen);
		}
		else if (TMPDD.value == 2)
		{
			Screen.SetResolution(1280, 720, Screen.fullScreen);
		}
	}

	public void ChangeVideo()
	{
		TMP_Dropdown TMPDD = GetComponent<TMP_Dropdown>();
		if (TMPDD.value == 0)
		{
			QualitySettings.SetQualityLevel(1);
		}
		else if (TMPDD.value == 1)
		{
			QualitySettings.SetQualityLevel(0);
		}
	}
}
