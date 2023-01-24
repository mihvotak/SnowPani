using Naninovel;
using UnityEngine;

[CommandAlias("sendWin")]
public class SendWin : Command
{
	public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
	{
		Debug.Log($"SendWin");
		ProxyJS.sendWin();

		return UniTask.CompletedTask;
	}
}
