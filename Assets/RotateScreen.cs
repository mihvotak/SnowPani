using UnityEngine;

public class RotateScreen : MonoBehaviour
{
	public GameObject FullScreenPanel;

    void Update()
    {
		bool show = Screen.width < Screen.height;
		if (FullScreenPanel.activeSelf != show)
			FullScreenPanel.SetActive(show);

	}
}
