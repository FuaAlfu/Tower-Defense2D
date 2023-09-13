using UnityEngine;
using System;

/// <summary>
/// 2023.9.12
/// </summary>

[Serializable]
public class HighScore
{
    public int highestScore;

    private static HighScore instance;

    public static HighScore Instance
    {
        get
        {
            if (instance == null)
            {
                instance = LoadHighScore();
            }
            return instance;
        }
    }

    private HighScore()
    {
        highestScore = 0;
    }

    private static HighScore LoadHighScore()
    {
        string jsonData = PlayerPrefs.GetString("HighScore", "");
        if (!string.IsNullOrEmpty(jsonData))
        {
            return JsonUtility.FromJson<HighScore>(jsonData);
        }
        else
        {
            return new HighScore();
        }
    }

    public void SaveHighScore()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("HighScore", jsonData);
        PlayerPrefs.Save();
    }

    public void UpdateHighScore(int newScore)
    {
        if (newScore > highestScore)
        {
            highestScore = newScore;
            SaveHighScore();
        }
    }
}
