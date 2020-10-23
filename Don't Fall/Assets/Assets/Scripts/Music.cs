using UnityEngine;

public class Music : MonoBehaviour
{
	[SerializeField] private AudioClip[] musicList = null;
	private AudioSource musicSource;

	private void Awake()
	{
		musicSource = GetComponent<AudioSource>();
	}
	void Update()
	{
		if (musicSource.isPlaying == false)
		{
			musicSource.clip = musicList[Random.Range(0, musicList.Length)];
			musicSource.Play();
		}
	}
}
