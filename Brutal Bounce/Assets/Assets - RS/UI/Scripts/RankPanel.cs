using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : MonoBehaviour
{
    public Animator panelRank;
    public bool activP;

    [SerializeField] LeaderboardManager leaderboardManager;

    public void Interact()
    {
        leaderboardManager.ShowLeaderboard();
        activP = !activP;
        panelRank.SetBool("Activ", activP);
    }
}
