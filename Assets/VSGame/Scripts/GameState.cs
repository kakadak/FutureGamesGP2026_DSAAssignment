using UnityEngine;

public enum GameState
{
    Playing, Paused, MainMenu, UpgradeMenu, GameOver, Settings,PauseSettings
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    public GameState CurrentState { get; private set; } = GameState.MainMenu;

    
    public GameObject mainMenuPanel;
    public GameObject menuCorePanel;
    public GameObject gameScreenPanel;
    public GameObject pausePanel;
    public GameObject upgradeMenuPanel;
    public GameObject gameOverPanel;
    public GameObject settingsPanel;
    public AudioSource mygame;
    public AudioSource cinema;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        SetState(CurrentState);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        UpdateUI();
    }

    private void UpdateUI()
    {
        mainMenuPanel.SetActive(CurrentState == GameState.MainMenu);
        menuCorePanel.SetActive(CurrentState == GameState.MainMenu);
        gameScreenPanel.SetActive(CurrentState == GameState.Playing || CurrentState == GameState.Paused || CurrentState == GameState.UpgradeMenu);
        pausePanel.SetActive(CurrentState == GameState.Paused);
        upgradeMenuPanel.SetActive(CurrentState == GameState.UpgradeMenu);
        gameOverPanel.SetActive(CurrentState == GameState.GameOver);
        settingsPanel.SetActive(CurrentState == GameState.Settings || CurrentState == GameState.PauseSettings);
        if(CurrentState == GameState.MainMenu && !cinema.isPlaying)
        {
            mygame.Stop();
            cinema.Play();
        }
        if(CurrentState == GameState.Playing && !mygame.isPlaying)
        {
            mygame.Play();
            cinema.Stop();
        }
    }

    public bool IsPlaying()
    {
        return CurrentState == GameState.Playing;
    }
    public bool IsPause()
    {
        return CurrentState == GameState.PauseSettings;
    }
    public bool IsMenu()
    {
        return CurrentState == GameState.Settings;
    }
}