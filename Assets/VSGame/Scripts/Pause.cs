using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public bool isPause = false;
    public GameObject gameScreen;
    public GameObject menuCore;
    public GameObject menu;
    public Spawn spawner;
    public LVL leveling;
    public PlayerHP life;
    public Timer clock;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && menu.activeSelf == false)
        {
            if(!isPause)
            {
                pause.SetActive(true);
                isPause = true;
                GameStateManager.Instance.SetState(GameState.Paused);
            }
            else
            {
                pause.SetActive(false);
                isPause = false;
                GameStateManager.Instance.SetState(GameState.Playing);
            }
        }
    }

    public void quit()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void resume()
    {
        pause.SetActive(false);
        isPause = false;
        GameStateManager.Instance.SetState(GameState.Playing);
    }

    public void meni()
    {
        gameScreen.SetActive(false);
        pause.SetActive(false);
        isPause = false;
        menu.SetActive(true);
        menuCore.SetActive(true);
        GameStateManager.Instance.SetState(GameState.MainMenu);
        leveling.experience = 0;
        leveling.level = 1;
        leveling.kills = 0;
        life.health = 100;
        clock.seconds = 0;
        clock.minutes = 0;
        foreach (GameObject enemy in spawner.activeEnemies)
        {
            Destroy(enemy);
        }
    }

    public void settings()
    {
        GameStateManager.Instance.SetState(GameState.PauseSettings);
    }
}
