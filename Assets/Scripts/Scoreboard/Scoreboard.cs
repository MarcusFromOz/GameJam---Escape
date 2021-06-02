using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresFrame = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        private string SavePath => $"{Application.persistentDataPath}/EscapeHighscores.json";
        GameObject title;

        private void Start()
        {
            title = GameObject.FindGameObjectWithTag("title");

            ScoreboardSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);
            SaveScores(savedScores);
        }


        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            //Firstly remove the current entries 
            foreach(Transform child in highscoresFrame)
            {
                Destroy(child.gameObject);
            }

            //Then repopulate the table
            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresFrame).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
            }

        }

        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }

        public void ShowScoreboard()
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.active);
            title.SetActive(!gameObject.transform.GetChild(0).gameObject.active);
        }
    }
}
