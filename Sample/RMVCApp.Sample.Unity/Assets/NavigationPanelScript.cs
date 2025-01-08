using RMVCApp.Sample.Core;
using RMVCApp.Sample.Core.Shared;
using System;
using UnityEngine;

public class NavigationPanelScript : MonoBehaviour, INavigationView
{
    public event Action ShowHomeViewEvt;
    public event Action ShowCounterViewEvt;
    public event Action ShowWeatherViewEvt;

    public void GoToHome() {
        ShowHomeViewEvt?.Invoke();
    }

    public void GoToCounter() {
        ShowCounterViewEvt?.Invoke();
    }

    public void GoToWeather() {
        ShowWeatherViewEvt?.Invoke();
    }

    void Start()
    {
        RMVCAppFacade.RegisterView(this);    
    }
    private void OnDestroy() {
        RMVCAppFacade.UnregisterView(this);
    }
}
