using System.Runtime.InteropServices;
using UnityEngine;

public class ProxyJS : MonoBehaviour
{
	[DllImport("__Internal")]
	private static extern bool IsIOSBrowser();
	[DllImport("__Internal")]
	private static extern bool IsMobile();
	[DllImport("__Internal")]
	private static extern float DevicePixelRatio();
	[DllImport("__Internal")]
	private static extern void GAsendScreenView(string screen_name);
	[DllImport("__Internal")]
	private static extern void GAsendSelectContent(string content_type, string item_id);
	[DllImport("__Internal")]
	private static extern void SendWin();

	public static bool? isMobile()
	{
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
		return null;
	}

	public static bool isIOSBrowser()
	{
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsIOSBrowser();
#endif
		return false;
	}

	public static float devicePixelRatio()
	{
#if !UNITY_EDITOR && UNITY_WEBGL
             return DevicePixelRatio();
#endif
		return 0;
	}

	public static void sendScreenView(string screen_name)
	{
#if !UNITY_EDITOR && UNITY_WEBGL
		GAsendScreenView(screen_name);
#endif
	}

	public static void sendSelectContent(string content_type, string item_id)
	{
#if !UNITY_EDITOR && UNITY_WEBGL
		GAsendSelectContent(content_type, item_id);
#endif
	}

	public static void sendWin()
	{
#if !UNITY_EDITOR && UNITY_WEBGL
		SendWin();
#endif
	}
}
