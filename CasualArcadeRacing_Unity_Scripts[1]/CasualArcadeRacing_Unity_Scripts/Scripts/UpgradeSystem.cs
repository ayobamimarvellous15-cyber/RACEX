using UnityEngine;

[System.Serializable]
public class CarStats
{
    public float topSpeed = 40f;
    public float acceleration = 1f;
    public float handling = 1f;
    public float nitro = 1f;
}

public class UpgradeSystem : MonoBehaviour
{
    public CarStats baseStats;
    public int upgradeCost = 100;

    public void UpgradeSpeed()
    {
        if (ProgressionSystem.Instance.coins >= upgradeCost)
        {
            ProgressionSystem.Instance.AddCoins(-upgradeCost);
            baseStats.topSpeed += 5f;
        }
    }

    public void UpgradeHandling()
    {
        if (ProgressionSystem.Instance.coins >= upgradeCost)
        {
            ProgressionSystem.Instance.AddCoins(-upgradeCost);
            baseStats.handling += 0.1f;
        }
    }
}
