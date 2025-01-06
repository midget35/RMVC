using Assets.Util;
using RMVC;
using RMVCApp.RMVC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class AppShell : MonoBehaviour, IAppShell
{
    [SerializeField] private MessageBoxScript MessageBox;

    private void Awake() {
        var gameObjects = UnityEngine.Object.FindObjectsByType<AppShell>(FindObjectsSortMode.None);
        if (gameObjects.Length > 1) {
            Destroy(gameObject); // Prevent duplicate persistent objects
            return;
        }

        DontDestroyOnLoad(gameObject);
        Console.SetOut(new DebugOutputMonitor());
        Context.Create(typeof(Context), this);
    }
    public void SetAppEnabled(bool doEnable) {

    }

    public async Task<bool> ShowMessageBox(string title, string message, bool isYesNo) {

        return await UnityMainThreadDispatcher.EnqueueAsync(() => MessageBox.Show(title, message, isYesNo));
    }
}
