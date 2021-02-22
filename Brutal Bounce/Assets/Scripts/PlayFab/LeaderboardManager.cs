using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] GameObject leaderboardEntity;
    bool opened = false;

    VerticalLayoutGroup layoutGroup;
    RectTransform rect;

    [SerializeField] TMPro.TMP_Text nameText;

    void Awake()
    {
        layoutGroup = GetComponent<VerticalLayoutGroup>();
        rect = GetComponent<RectTransform>();
    }

    public void ShowLeaderboard()
    {
        if (opened) return;
        var request = new GetLeaderboardRequest { StatisticName = "Score", MaxResultsCount = 10 };
        PlayFabClientAPI.GetLeaderboard(request, ShowLeaderboardSuccess, error => { });
    }

    private void ShowLeaderboardSuccess(GetLeaderboardResult result)
    {
        var leaderboard = result.Leaderboard;
        foreach (PlayerLeaderboardEntry entry in leaderboard)
        {
            if (entry.StatValue > 0)
            {
                var currentLeaderboardEntity = Instantiate(leaderboardEntity, transform);
                currentLeaderboardEntity.GetComponent<LeaderboardEntity>().SetInformation(entry.Position + 1, entry.DisplayName, entry.StatValue, nameText.text);
            }
        }
        opened = true;
    }
}