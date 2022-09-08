const {app,BrowserWindow,ipcMain}=require('electron')

const electronReload = require('electron-reload')

const path=require('path')
const url=require('url')


let win 
let login
let signup

function createWindows() {
    
    win =new BrowserWindow({width:1100,height:800,show: false, webPreferences: {
      nodeIntegration: true,
      contextIsolation: false
  }})

    win.loadURL(url.format({
        pathname:path.join(__dirname,'index.html'),
        protocol:'file',
        slashes:true
    }))
    
    login = new BrowserWindow({parent: win,width:1100,height:800,frame:true, webPreferences: {
      nodeIntegration: true,
      contextIsolation: false
  }})
    login.loadURL(url.format({
        pathname:path.join(__dirname,'login.html'),
        protocol:'file',
        slashes:true
    }))

    login.openDevTools()

    signup = new BrowserWindow({parent: win,width:1100,height:800,frame:true,show:false, webPreferences: {
      nodeIntegration: true,
      contextIsolation: false
  }})
    signup.loadURL(url.format({
        pathname:path.join(__dirname,'../src/sign/signUp.html'),
        protocol:'file',
        slashes:true
    }))

    signup.openDevTools()
}

ipcMain.on('entry-accepted', (event, arg) => {
    if(arg=='ping'){
        win.show()
        login.hide()
        signup.hide()
    }
  })

app.on('ready',createWindows)