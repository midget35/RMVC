const { app, BrowserWindow, Menu } = require('electron');
const path = require('path');
const express = require('express');
const isDev = !app.isPackaged;

// Set up Express server to serve the Blazor content
const expressApp = express();
const PORT = 3000;

// Determine the path to wwwroot depending on the environment
let blazorWwwrootPath;

if (isDev) {
    blazorWwwrootPath = path.resolve(__dirname, '../RMVCApp.Sample.Blazor/bin/Release/net8.0/browser-wasm/publish/wwwroot');
} else {
    blazorWwwrootPath = path.resolve(__dirname, 'wwwroot');
}
console.log("Blazor WWW Root Path: " + blazorWwwrootPath);
// Serve the Blazor files from the 'wwwroot' directory
expressApp.use(express.static(blazorWwwrootPath));

// Middleware to set correct MIME types
expressApp.use((req, res, next) => {
    try {
        const mime = require('mime');
        const fileType = mime.getType(req.path);
        if (fileType) {
            res.type(fileType);
        }
    } catch (err) {
        console.error("Error loading MIME type:", err);
    }
    next();
});

// Start Express server
expressApp.listen(PORT, () => {
    console.log(`Express server is running on http://localhost:${PORT}`);

    function createWindow() {
        console.log("Starting createWindow function...");

        const win = new BrowserWindow({
            width: 1024,
            height: 768,
            webPreferences: {
                preload: path.join(__dirname, 'preload.js'),
                contextIsolation: true,
                nodeIntegration: false,
                webSecurity: false,
                allowRunningInsecureContent: true,
            }
        });

        console.log("BrowserWindow created successfully.");

        // Remove default menu bar
        if (!isDev) {
            win.removeMenu();
        }

        win.webContents.session.clearCache().then(() => {
            win.loadURL(`http://localhost:${PORT}`)
                .then(() => {
                    console.log("Blazor app loaded successfully from Express server.");
                    if (isDev) {
                        win.webContents.openDevTools();
                    }
                })
                .catch((err) => {
                    console.error("Failed to load Blazor app:", err);
                });
        });

        win.on('closed', () => {
            console.log("Window closed.");
        });
    }

    app.on('ready', () => {
        console.log("Electron app is ready. Creating window...");
        createWindow();
    });

    app.on('window-all-closed', () => {
        console.log("All windows closed.");
        if (process.platform !== 'darwin') {
            console.log("Quitting app...");
            app.quit();
        }
    });

    app.on('activate', () => {
        console.log("App activated.");
        if (BrowserWindow.getAllWindows().length === 0) {
            console.log("No windows are open, creating a new one...");
            createWindow();
        }
    });
});
