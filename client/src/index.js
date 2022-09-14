const electron = require("electron");

const { app, BrowserWindow,ipcMain } = electron;

const electronReload = require('electron-reload')
const fetch = require("electron-fetch").default;

const path=require('path')
const url=require('url')

let user;
let programs;
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
ipcMain.on("userlogin", (event, data) => {
  console.log(data)
      fetch('https://localhost:7179/User/Login', {
        method: "POST",
        body: data,
        headers: { 'Content-Type': 'application/json' },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log("succes:",data);
          user = data;
          win.loadURL(`file://${__dirname}/index.html`)
        })
        .catch((error) => {
          console.error("Error:", error);
        });
});

ipcMain.on("usersignup", (event, data) => {
  console.log(data)
      fetch('https://localhost:7179/User/Register', {
        method: "POST",
        body: data,
        headers: { 'Content-Type': 'application/json' },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log("succes:",data);
          user = data;
          win.loadURL(`file://${__dirname}/chooseContent.html`)
        })
        .catch((error) => {
          console.error("Error:", error);
        });
});

ipcMain.on("getPrograms", (event) => {
      fetch('https://localhost:7179/User/Program')
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        win.webContents.send('store-programs', data);
      })
        .catch((error) => {
          console.error("Error:", error);
        });
});

ipcMain.on("userInterest", (event, data) => {
      dataLast = {
        interestId: data,
        userId: user.id
      }
      fetch('https://localhost:7179/User/Interest', {
        method: "POST",
        body: JSON.stringify(dataLast),
        headers: { 'Content-Type': 'application/json' },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log("succes:",data);
          win.loadURL(`file://${__dirname}/index.html`)
        })
        .catch((error) => {
          console.error("Error:", error);
        });
});

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