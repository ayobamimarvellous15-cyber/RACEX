using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Text countdownText;
    public Text speedText;
    public Slider nitroSlider;
    public Text coinsText;

    public GameObject resultsPanel;
    public Text resultsText;

    public void ShowCountdown(int seconds, Action onComplete)
    {
        StartCoroutine(CountdownRoutine(seconds, onComplete));
    }

    System.Collections.IEnumerator CountdownRoutine(int s, Action onComplete)
    {
        int t = s;
        while (t > 0)
        {
            if (countdownText) countdownText.text = t.ToString();
            t--;
            yield return new WaitForSeconds(1f);
        }
        if (countdownText) countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        if (countdownText) countdownText.gameObject.SetActive(false);
        onComplete?.Invoke();
    }

    void Update()
    {
        var car = FindObjectOfType<CarController>();
        if (car != null)
        {
            if (speedText) speedText.text = Mathf.RoundToInt(car.currentSpeed * 3.6f).ToString() + " km/h";
            if (nitroSlider) nitroSlider.value = 0f; // placeholder - hook to nitro system if present
        }
        if (coinsText) coinsText.text = ProgressionSystem.Instance ? ProgressionSystem.Instance.coins.ToString() : "0";
    }

    public void ShowResults()
    {
        if (resultsPanel) resultsPanel.SetActive(true);
        if (resultsText) resultsText.text = "Race Finished!";
    }
}
