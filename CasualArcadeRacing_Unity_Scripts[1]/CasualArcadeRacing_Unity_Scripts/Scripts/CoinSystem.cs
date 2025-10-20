using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public int value = 10;
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CarController>();
        if (player != null)
        {
            ProgressionSystem.Instance?.AddCoins(value);
            Destroy(gameObject);
        }
    }
}
