using Naninovel;
using UnityEngine;

[CommandAlias("sendScreenView")]
public class SendScreenView : Command
{
	public StringParameter ScreenName;

	public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
	{
		if (Assigned(ScreenName))
		{
			Debug.Log($"SendScreenView: {ScreenName}");
			ProxyJS.sendScreenView(ScreenName.ToString());
		}
		else
		{
			Debug.LogError("SendPageView without parameter!");
		}

		return UniTask.CompletedTask;
	}
}
