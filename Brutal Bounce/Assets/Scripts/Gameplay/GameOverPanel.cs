using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab.ClientModels;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TMP_Text scoreToShow;
    [SerializeField] TMP_Text maxScoreToShow;

    void OnEnable()
    {
        GameOverSetup();
    }

    private void GameOverSetup()
    {
        scoreToShow.text = scoreManager.GetScore().ToString();

        var request = new GetPlayerStatisticsRequest { StatisticNames = { "Score" } };
        PlayFab.PlayFabClientAPI.GetPlayerStatistics(request, GetScoreSuccess, error => { });
    }

    private void GetScoreSuccess(GetPlayerStatisticsResult result)
    {
        int maxScore = result.Statistics[0].Value;
        if (maxScore < scoreManager.GetScore())
        {
            maxScoreToShow.text = scoreManager.GetScore().ToString();
        }
        else
        {
            maxScoreToShow.text = maxScore.ToString();
        }
    }
}
