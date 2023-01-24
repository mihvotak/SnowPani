using UnityEngine;

public class RotateScreen : MonoBehaviour
{
	public RectTransform RotatePanel;
	public RectTransform FullScreenButton;
	
	void Update()
    {
		bool showRotate = Screen.width < Screen.height;
		if (RotatePanel.gameObject.activeSelf != showRotate)
			RotatePanel.gameObject.SetActive(showRotate);

	}
}
