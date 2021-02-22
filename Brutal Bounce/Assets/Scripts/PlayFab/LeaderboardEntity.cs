﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LeaderboardEntity : MonoBehaviour
{
    [SerializeField] TMP_Text position;
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text score;

    [SerializeField] Color32 currentPlayerColor;

    public void SetInformation(int position, string name, int score, string playerName)
    {
        this.position.text = position.ToString();
        this.name.text = name;
        this.score.text = score.ToString();

        if (name == playerName)
        {
            this.position.color = currentPlayerColor;
            this.name.color = currentPlayerColor;
            this.score.color = currentPlayerColor;
        }
    }
}

