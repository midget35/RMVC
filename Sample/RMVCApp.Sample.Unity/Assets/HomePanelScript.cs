using RMVCApp.RMVC;
using RMVCApp.RMVC.Shared;
using System;
using UnityEngine;

public class HomePanelScript : MonoBehaviour, IHomeView
{
    public event Action<string> ShowRmvcMessageEvt;
    public event Action RunRmvcProgressTestEvt;

    public void SetView() {

    }
    public void OnShowRmvcTestMessage() 
    {
        ShowRmvcMessageEvt?.Invoke("Hello from RMVC.");
    }
    public void RunRmvcProgressTest() {
        RunRmvcProgressTestEvt?.Invoke();
    }
    void Start() {
        Context.RegisterView(this);
    }
    private void OnDestroy() {
        Context.UnregisterView(this);
    }

}
