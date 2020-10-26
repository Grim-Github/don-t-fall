using UnityEngine;
using UnityEngine.UI;

public class shopPreview : MonoBehaviour
{
	public static Image previewImage = null;

	private void Awake()
	{
		previewImage = GetComponent<Image>();
	}
}
