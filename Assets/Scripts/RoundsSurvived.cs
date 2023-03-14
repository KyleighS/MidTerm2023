using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsNUM;

    void OnEnable()
    {
        roundsNUM.text = PlayerStats.rounds.ToString();
    }
}
