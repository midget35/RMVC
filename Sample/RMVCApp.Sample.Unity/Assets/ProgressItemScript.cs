using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressItemScript : MonoBehaviour {
    [SerializeField] private TMP_Text headingText;
    [SerializeField] private TMP_Text percentText;
    [SerializeField] private Slider progressSlider;

    public void UpdateProgress(string heading, int percent) {
        headingText.text = heading;
        percentText.text = $"{percent}%";
        //progressSlider.value = percent;
        progressSlider.SetValueWithoutNotify(percent);
    }
}