using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject menu;
    public GameObject menuCore;
    public LVL leveling;
    public PlayerHP life;
    public Character PlayerScript;
    public Timer clock;
    public Spawn spawner;
    public GameObject GameOverScreen;
    public Menu menin;
    public AudioSource gameovering;
    void Update()
    {
        if (life.health <= 0 && GameStateManager.Instance.CurrentState != GameState.GameOver)
        {
            GameStateManager.Instance.SetState(GameState.GameOver);
            gameovering.Play();
            
            if(leveling.kills > menin.highscore)
            {
                menin.highscore = leveling.kills;
                PlayerPrefs.SetInt("Highscore", leveling.kills);
            }
            
            
        }
    }

    public void restart()
    {
        ResetGame();
        GameStateManager.Instance.SetState(GameState.Playing);
    }

    public void meni()
    {
        ResetGame();
        GameStateManager.Instance.SetState(GameState.MainMenu);
    }

    private void ResetGame()
    {
        leveling.experience = 0;
        leveling.level = 1;
        leveling.kills = 0;
        life.health = 100;
        clock.ResetTimer();
        foreach (GameObject enemy in spawner.activeEnemies)
        {  
            Destroy(enemy);
        }
        spawner.activeEnemies.Clear();
    }
}