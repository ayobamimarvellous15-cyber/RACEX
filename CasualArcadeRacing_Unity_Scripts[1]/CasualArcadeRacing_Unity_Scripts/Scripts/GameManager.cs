using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Menu, CountDown, Racing, Finished }
    public GameState State { get; private set; } = GameState.Menu;

    public List<GameObject> racers;
    public Transform[] startPositions;

    public UIManager uiManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        State = GameState.CountDown;
        if (uiManager != null) uiManager.ShowCountdown(3, OnCountdownComplete);
    }

    void OnCountdownComplete()
    {
        State = GameState.Racing;
        foreach (var r in racers) if (r) r.SetActive(true);
    }

    public void FinishRace()
    {
        State = GameState.Finished;
        uiManager?.ShowResults();
        ProgressionSystem.Instance?.OnRaceFinished(1);
    }

    public void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
