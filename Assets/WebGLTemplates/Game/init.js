
window.dataLayer = window.dataLayer || [];
function gtag(){dataLayer.push(arguments);}
gtag('js', new Date());

gtag('config', 'G-PKG8LVZZGC', { 'app_name': "SnowPani", 'app_version': "2023.01.23" });

var sendScreenView = function(screen_name)
{
	gtag('event', 'page_view', {
		'page_title' : screen_name
	});

	gtag('event', 'screen_view', {
		'screen_name' : screen_name
	});
}
sendScreenView("InitJS");

var sendSelectContent = function(content_type, item_id)
{
	gtag('event', 'select_content', {
		'content_type' : content_type,
		'item_id' : item_id
	});
}


var sendWin = function()
{
	gtag('event', 'tutorial_complete');
}

var container = document.querySelector("#unity-container");
var canvas = document.querySelector("#unity-canvas");
var loadingBar = document.querySelector("#unity-loading-bar");
var progressBarFull = document.querySelector("#unity-progress-bar-full");
var fullscreenButton = document.querySelector("#unity-fullscreen-button");
var warningBanner = document.querySelector("#unity-warning");

// Shows a temporary message banner/ribbon for a few seconds, or
// a permanent error message on top of the canvas if type=='error'.
// If type=='warning', a yellow highlight color is used.
// Modify or remove this function to customize the visually presented
// way that non-critical warnings and error messages are presented to the
// user.
function unityShowBanner(msg, type) {
  function updateBannerVisibility() {
    warningBanner.style.display = warningBanner.children.length ? 'block' : 'none';
  }
  var div = document.createElement('div');
  div.innerHTML = msg;
  warningBanner.appendChild(div);
  if (type == 'error') div.style = 'background: red; padding: 10px;';
  else {
    if (type == 'warning') div.style = 'background: yellow; padding: 10px;';
    setTimeout(function() {
      warningBanner.removeChild(div);
      updateBannerVisibility();
    }, 000);
  }
  updateBannerVisibility();
}

var buildUrl = baseUrl + "Build";
var loaderUrl = buildUrl + "/build.loader.js";
var config = {
  dataUrl: buildUrl + "/build.data.br",
  frameworkUrl: buildUrl + "/build.framework.js.br",
  codeUrl: buildUrl + "/build.wasm.br",
  streamingAssetsUrl: baseUrl + "StreamingAssets",
  companyName: "SGG",
  productName: "SnowPani",
  productVersion: "2023.01.23",
  showBanner: unityShowBanner,
};

// By default Unity keeps WebGL canvas render target size matched with
// the DOM size of the canvas element (scaled by window.devicePixelRatio)
// Set this to false if you want to decouple this synchronization from
// happening inside the engine, and you would instead like to size up
// the canvas DOM size and WebGL render target sizes yourself.
// config.matchWebGLToCanvasSize = false;


var meta = document.createElement('meta');
meta.name = 'viewport';
meta.content = 'width=device-width, height=device-height, initial-scale=1.0, user-scalable=no, shrink-to-fit=yes';
document.getElementsByTagName('head')[0].appendChild(meta);
container.className = "unity-mobile";
canvas.className = "unity-mobile";

if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) 
	unityShowBanner('Игра не оптимизирована под мобильные устройства. Запускайте на свой страх и риск.');

loadingBar.style.display = "block";

var script = document.createElement("script");
script.src = loaderUrl;
script.onload = () => {
  createUnityInstance(canvas, config, (progress) => {
    progressBarFull.style.width = 100 * progress + "%";
  }).then((unityInstance) => {
    loadingBar.style.display = "none";
    fullscreenButton.onclick = () => {
      unityInstance.SetFullscreen(1);
    };
  }).catch((message) => {
    alert(message);
  });
};
document.body.appendChild(script);

var link_styles = document.createElement("link");
link_styles.type = "text/css";
link_styles.rel = "stylesheet";
link_styles.href = baseUrl + "TemplateData/style.css?" + Date.now();
document.head.appendChild(link_styles);

//var link_icon = document.createElement("link");
//link_icon.rel = "shortcut icon";
//link_icon.href = baseUrl + "TemplateData/favicon.ico";
//document.head.appendChild(link_icon);
