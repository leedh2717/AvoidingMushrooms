using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static Define;

public class GameData
{
    public int bestScore;
    public float volumeValue = 1;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameData gameData = new GameData();
    string path;

    public int PlayerAttack { get; set; }
    public int PlayerHp { get; set; }
    public int PlayerCurrentHp { get; set; }

    public int BossHp { get; set; }
    public int BossCurrentHp { get; set; }
    public bool IsBoss { get; set; }

    public StageLevel StageLevel { get; set; }
    public StagePhase StagePhase { get; set; }

    public int Score { get; set; }

    float volumeValue;
    public float VolumeValue 
    {
        get
        {
            return volumeValue;
        }
        set
        {
            volumeValue = value;
            gameData.volumeValue = volumeValue;
            SaveData();
            LoadData();
        }
    }

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/";

        if (!File.Exists(path + "GameData"))
            SaveData();

        Init();
    }

    public void Init()
    {
        LoadData();

        Score = 0;

        if (Time.timeScale == 0)
            Time.timeScale = 1;
        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(gameData);
        File.WriteAllText(path + "GameData", data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + "GameData");
        gameData = JsonUtility.FromJson<GameData>(data);
    }

    public void ScoreCompare()
    {
        if (gameData.bestScore < Score)
        {
            gameData.bestScore = Score;
            SaveData();
            LoadData();
        }
    }

}
