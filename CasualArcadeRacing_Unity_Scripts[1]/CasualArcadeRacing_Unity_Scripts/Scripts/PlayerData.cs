using UnityEngine;

[System.Serializable]
public class PlayerDataModel
{
    public int coins = 0;
    public int level = 1;
}

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    public PlayerDataModel data;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Save()
    {
        data.coins = ProgressionSystem.Instance ? ProgressionSystem.Instance.coins : data.coins;
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("player_data", json);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("player_data"))
        {
            data = JsonUtility.FromJson<PlayerDataModel>(PlayerPrefs.GetString("player_data"));
            if (ProgressionSystem.Instance) ProgressionSystem.Instance.coins = data.coins;
        }
        else data = new PlayerDataModel();
    }
}
