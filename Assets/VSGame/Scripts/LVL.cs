using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LVL : MonoBehaviour
{
    public Slider XP;
    public int experience;
    public TextMeshProUGUI lvlText; 
    public int level = 1;  
    public int kills = 0;
    public int need = 100;    
    public TextMeshProUGUI killer;
    public AudioSource levelup;
    void Update()
    {
        killer.text = "Kills:\n" + kills;
        XP.value = experience;
        lvlText.text = "Level: " + level;
        XP.maxValue = need;
        if (experience >= need)
        {
            level += 1;
            levelup.Play();
            lvlUpdate();
            experience = 0;
        }
    }
    void lvlUpdate()
    {
        GameStateManager.Instance.SetState(GameState.UpgradeMenu);

    }
}