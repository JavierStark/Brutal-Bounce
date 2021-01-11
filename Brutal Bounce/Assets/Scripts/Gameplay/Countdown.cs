using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    TMP_Text countdownDisplay;

    [SerializeField] Player player;
    [SerializeField] EventHandler eventHandler;
    [SerializeField] GameObject inputCanvas;
    [SerializeField] Ball ball;


    void Start()
    {
        countdownDisplay = GetComponentInChildren<TMP_Text>();
        StartCoroutine(InitialCountdown());
    }

    IEnumerator InitialCountdown()
    {
        for (int i = 3; i >= 0; i--)
        {
            countdownDisplay.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        this.gameObject.SetActive(false);
        player.GameStarted();
        ball.GameStarted();
        eventHandler.GameStarted();
        inputCanvas.SetActive(true);
    }
}
