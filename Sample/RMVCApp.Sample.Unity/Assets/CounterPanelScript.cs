using RMVCApp.RMVC;
using RMVCApp.RMVC.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterPanelScript : MonoBehaviour, ICounterView
{
    [SerializeField] private TextMeshProUGUI counterText;
    
    public event Action<int> SetCounterEvt;

    private int count = 0;

    public void SetCounter(int count) {
        this.count = count;
        counterText.text = count.ToString();
    }
    public void OnIncrementCounter() {
        count++;
        counterText.text = count.ToString();
        SetCounterEvt?.Invoke(count);
    }
    void Start() {
        Context.RegisterView(this);
    }
    private void OnDestroy() {
        Context.UnregisterView(this);
    }

}
