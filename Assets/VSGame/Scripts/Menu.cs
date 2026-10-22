using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int highscore;
    public TextMeshProUGUI high;
    
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    void Update()
    {
        high.text = "HIGHSCORE:\n" + highscore;
    }

    public void play()
    {
        GameStateManager.Instance.SetState(GameState.Playing);
    }

    public void quit()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void settings()
    {
        GameStateManager.Instance.SetState(GameState.Settings);
    }
}
