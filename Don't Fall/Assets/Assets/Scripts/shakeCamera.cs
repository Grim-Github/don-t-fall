using Cinemachine;
using UnityEngine;

public class shakeCamera : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera cmc = null;
	private Player player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void FixedUpdate()
	{
		float playerVelocity = player.gameObject.GetComponent<Rigidbody2D>().velocity.y;
		if (playerVelocity <= -3.5f)
		{
			cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain, 3, Time.deltaTime * 2);
			cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.Lerp(cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain, 1, Time.deltaTime * 2);
		}
		else
		{
			cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain, 0, Time.deltaTime * 2);
			cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.Lerp(cmc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain, 0, Time.deltaTime * 2);
		}

	}
}
