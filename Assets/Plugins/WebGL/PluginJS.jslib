var PluginJS = {
	GAsendScreenView: function (screen_name) {
		sendScreenView(UTF8ToString(screen_name));
	},

	GAsendSelectContent: function (content_type, item_id) {
		sendSelectContent(UTF8ToString(content_type), UTF8ToString(item_id));
	},

	SendWin: function () {
		sendWin();
	},

	IsMobile: function()
	{
		return /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
	},

	DevicePixelRatio: function()
	{
		return window.devicePixelRatio;
	},

	IsIOSBrowser: function () {
		return (/iPhone|iPad|iPod/i.test(navigator.userAgent));
	}
};
 
mergeInto(LibraryManager.library, PluginJS);
 