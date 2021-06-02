using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryDateText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {
            entryDateText.text = scoreboardEntryData.entryDate;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString() + " seconds left";
        }

    }
}

