using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LeaderboardEntity : MonoBehaviour
{
    TMP_Text position;
    TMP_Text name;
    TMP_Text score;

    public void SetInformation(string position, string name, string score)
    {
        this.position.text = position;
        this.name.text = name;
        this.score.text = score;
    }
}

