using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LeaderboardEntity : MonoBehaviour
{
    [SerializeField] TMP_Text position;
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text score;

    public void SetInformation(int position, string name, int score)
    {
        this.position.text = position.ToString();
        this.name.text = name;
        this.score.text = score.ToString();
    }
}

