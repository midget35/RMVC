using RMVCApp.Sample.Core;
using RMVCApp.Sample.Core.Shared;
using TMPro;
using UnityEngine;

public class WeatherPanelScript : MonoBehaviour, IWeatherView
{
    [SerializeField] private GameObject weatherTable;       
    [SerializeField] private GameObject weatherRowPrefab;   

    public void SetView(WeatherForecastDTO[] forecasts) {

        // Clear existing rows, if any
        foreach (Transform child in weatherTable.transform) {
            Destroy(child.gameObject);
        }

        // Instantiate a row for each forecast
        foreach (var forecast in forecasts) {
            GameObject row = Instantiate(weatherRowPrefab, weatherTable.transform);

            // Assign values to each Text component in the row
            row.transform.Find("DateText").GetComponent<TextMeshProUGUI>().text = forecast.Date.ToShortDateString();
            row.transform.Find("TempCText").GetComponent<TextMeshProUGUI>().text = forecast.TemperatureC + " °C";
            row.transform.Find("TempFText").GetComponent<TextMeshProUGUI>().text = forecast.TemperatureF + " °F";
            row.transform.Find("SummaryText").GetComponent<TextMeshProUGUI>().text = forecast.Summary ?? "";
        }
    }
    void Start() {
        RMVCAppFacade.RegisterView(this);
    }
    private void OnDestroy() {
        RMVCAppFacade.UnregisterView(this);
    }

}
