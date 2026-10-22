using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public GameObject settings;
    public AudioSource auone;
    public AudioSource autwo;
    public AudioSource menumusic;
    public AudioSource levelup;
    public AudioSource gamemusic;
    public AudioSource playeratk;
    public AudioSource GameOver;
    public AudioSource Nee;
    public Scrollbar sfxScroll;
    public Scrollbar musicScroll;
    public TextMeshProUGUI syncer;
    public Menu menin;
    public void fullscreen()
    {
        Screen.fullScreen = true;
    }
    public void windowed()
    {
        Screen.fullScreen = false;
    }
    public void back()
    {
        if(GameStateManager.Instance.IsMenu())
        {
            GameStateManager.Instance.SetState(GameState.MainMenu);
        }
        else if(GameStateManager.Instance.IsPause())
        {
            GameStateManager.Instance.SetState(GameState.Paused);

        }

    }
    public void SFX()
    {
        auone.volume = sfxScroll.value;
        autwo.volume = sfxScroll.value;
        levelup.volume = sfxScroll.value; 
        playeratk.volume = sfxScroll.value;
        GameOver.volume = sfxScroll.value;
        Nee.volume = sfxScroll.value;
        auone.Play();
    }
    public void Music()
    {
        menumusic.volume = musicScroll.value;
        gamemusic.volume = musicScroll.value;


    }
    public void reseting()
    {
        menin.highscore = 0;
        PlayerPrefs.SetInt("Highscore", 0);
    }
    public void vsyncing()
    {
        if(QualitySettings.vSyncCount == 1)
        {
            QualitySettings.vSyncCount = 0;
            syncer.text = "Vsync: OFF";
        }
        else
        {
            QualitySettings.vSyncCount = 1;
            syncer.text = "Vsync: ON";
        }
        
    }

}
