using Assets.Util;
using RMVCApp.Sample.Core;
using System;
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
        RMVCAppFacade.Create(typeof(RMVCAppFacade), this);
    }
    public void SetAppEnabled(bool doEnable) {

    }

    public async Task<bool> ShowMessageBox(string title, string message, bool isYesNo) {

        return await UnityMainThreadDispatcher.EnqueueAsync(() => MessageBox.Show(title, message, isYesNo));
    }
}
