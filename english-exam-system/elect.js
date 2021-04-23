// ./main.js
const {app, BrowserWindow} = require('electron')

let win = null;

app.dock.hide();

app.on('ready', function () {

  // Initialize the window to our specified dimensions
  win = new BrowserWindow({fullscreen: true,frame: false});
  win.removeMenu();
  win.setSkipTaskbar(true);

  // Specify entry point to default entry point of vue.js
  win.loadURL('http://localhost:8080');

  // Remove window once app is closed
  win.on('closed', function () {
  win = null;
  });

});
//create the application window if the window variable is null
app.on('activate', () => {
  if (win === null) {
  createWindow()
  }
})
//quit the app once closed
app.on('window-all-closed', function () {
  if (process.platform != 'darwin') {
  app.quit();
  }
});