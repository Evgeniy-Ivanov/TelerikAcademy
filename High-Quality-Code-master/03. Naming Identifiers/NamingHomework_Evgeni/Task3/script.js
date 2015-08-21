function checkBrowser() {
  var activeWindow = window,
      browser = activeWindow.navigator.appCodeName,
      isMozila = browser == "Mozilla";
  if (isMozila) {
    alert("Yes");
  } else {
    alert("No");
  }
}