using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;

public class CountdownUIController : MonoBehaviour
{
    public Slider progressBar;
    public TextMeshProUGUI countdownText;
    public float startingTime = 180f;
    public UnityEvent OnTimeOut;

    private float timeLeft;
    private int lastDisplayedTime;
    private bool isCounting = false;
    private bool isDisplayed = false;

    private void Start()
    {
        progressBar.maxValue = startingTime;
        timeLeft = startingTime;
        lastDisplayedTime = Mathf.RoundToInt(timeLeft) + 1;
        progressBar.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);

        if (OnTimeOut == null)
            OnTimeOut = new UnityEvent();
    }

    public void StartCountdown()
    {
        isCounting = true;
        Invoke("DisplayCountdown", 7f);
        
    }

    private void DisplayCountdown()
    {
        isDisplayed = true;
        progressBar.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!isCounting || !isDisplayed) return;

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            progressBar.value = timeLeft;

            int currentRoundedTime = Mathf.RoundToInt(timeLeft);
            if (currentRoundedTime != lastDisplayedTime)
            {
                countdownText.text = currentRoundedTime + "s";
                lastDisplayedTime = currentRoundedTime;
            }

            if (timeLeft <= 50f)
                progressBar.fillRect.GetComponent<Image>().color = Color.red;
            else
                progressBar.fillRect.GetComponent<Image>().color = Color.green;
        }
        else
        {
            OnTimeOut.Invoke();
            isCounting = false;
            progressBar.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);
        }
    }
}