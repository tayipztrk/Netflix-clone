const electron = require("electron");

const { app, BrowserWindow,ipcMain } = electron;

const electronReload = require('electron-reload')

const path=require('path')
const url=require('url')


let win 
let login
let signup

function createWindows() {
    
    win =new BrowserWindow({width:1100,height:800,webPreferences: {
      nodeIntegration: true,
      contextIsolation: false,
  }})

    win.loadURL(`file://${__dirname}/login.html`)
  
}

ipcMain.on("authenticated", async (event) => {
        // win.show()
        // login.hide()
        // signup.hide()
        win.loadURL(`file://${__dirname}/index.html`)
  })

  ipcMain.on("unauthenticated", (event) => {

    win.loadURL(`file://${__dirname}/signIn.html`)
  })

app.on('ready',createWindows)