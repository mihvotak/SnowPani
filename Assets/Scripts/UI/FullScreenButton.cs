using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class FullScreenButton : Button
{
	public Image IconImage;
	public Sprite NormalOff;
	public Sprite NormalOn;

	public Color NormalColor;
	public Color HoverColor;
	public Color DisabledColor;

	protected override void Start()
	{
		UpdateView(true);
		onClick.AddListener(() => OnDeselect(null));
	}

	private float _lastTime;
	public float PausePeriod = .5f;
	public override void OnPointerDown(PointerEventData eventData)
	{
		if (_disabled)
			return;
		if (eventData.button != PointerEventData.InputButton.Left)
			return;
		float time = Time.realtimeSinceStartup;
		if (time - _lastTime < PausePeriod)
			return;
		_lastTime = time;
		Screen.fullScreen = !Screen.fullScreen;
		Debug.Log("Screen.fullScreen=" + Screen.fullScreen);
		UpdateView(true);
		base.OnPointerDown(eventData);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		OnDeselect(null);
	}

	private bool _on;

	private void Update()
	{
		UpdateView(false);
	}

	private void UpdateView(bool force)
	{
		if (_on != Screen.fullScreen || force)
		{
			_on = Screen.fullScreen;
			//var state = spriteState;
			//state.pressedSprite = _on ? PressedOn : PressedOff;
			//state.highlightedSprite = _on ? PressedOn : PressedOff;
			//state.disabledSprite = _on ? DisabledOn : DisabledOff;
			//spriteState = state;
			//(targetGraphic as Image).sprite = _disabled ? DisabledOff : _on ? NormalOn : NormalOff;
			IconImage.sprite = _on ? NormalOn : NormalOff;
		}
	}

	private bool _disabled;
	public bool Disabled
	{
		get
		{
			return _disabled;
		}
		set
		{
			_disabled = value;
			enabled = !_disabled;
			UpdateView(true);
		}
	}

}
