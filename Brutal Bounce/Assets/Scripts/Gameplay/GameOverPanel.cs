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


    [SerializeField] Player player;
    [SerializeField] EventHandler eventHandler;
    [SerializeField] GameObject inputCanvas;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GameOverSetup()
    {
        EndProcesses();
        transform.GetChild(0).gameObject.SetActive(true);
        scoreToShow.text = scoreManager.GetScore().ToString();

        var request = new GetPlayerStatisticsRequest { StatisticNames = new List<string>() { "Score" } };
        PlayFab.PlayFabClientAPI.GetPlayerStatistics(request, GetScoreSuccess, ScriptExecutionError => { });
    }

    private void EndProcesses()
    {
        player.GameEnded();
        eventHandler.GameEnded();
        inputCanvas.SetActive(false);
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

    public void ResetScene()
    {
        LoadManager.Instance.ChangeSceneWithLoading("GameScene");
    }
    public void MenuScene()
    {
        LoadManager.Instance.ChangeSceneWithLoading("MainMenuScene");
    }
}
