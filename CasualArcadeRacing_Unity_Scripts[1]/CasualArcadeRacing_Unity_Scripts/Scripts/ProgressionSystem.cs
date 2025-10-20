using UnityEngine;

public class ProgressionSystem : MonoBehaviour
{
    public static ProgressionSystem Instance { get; private set; }

    public int coins = 0;
    public int xp = 0;
    public int playerLevel = 1;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void AddXP(int amount)
    {
        xp += amount;
        if (xp >= 100)
        {
            xp -= 100;
            playerLevel++;
        }
    }

    public void OnRaceFinished(int place)
    {
        int reward = 0;
        if (place == 1) reward = 100;
        else if (place == 2) reward = 60;
        else reward = 30;
        AddCoins(reward);
        AddXP(20);
    }
}
