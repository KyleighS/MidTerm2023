using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesTxt;

    // Update is called once per frame
    void Update()
    {
        livesTxt.text = PlayerStats.lives + " Lives";
    }
}
