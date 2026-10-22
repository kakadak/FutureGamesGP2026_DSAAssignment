using UnityEngine;
using TMPro;
public class UpgradeMenu : MonoBehaviour
{
    public Character player;
    public LVL leveling;
    public TextMeshProUGUI aspeed;
    public TextMeshProUGUI damager;
    public TextMeshProUGUI speeder;

    public int asir = 1;
    public int dmg = 1;
    public int sp = 1;
    public void AttackSpeed()
    {
        player.attackFrameRate -= 0.02f;
        leveling.need *= 2;
        asir += 1;
        aspeed.text = "Attack Speed lvl." + asir;
        GameStateManager.Instance.SetState(GameState.Playing);
        
    }
    public void Damage()
    {
        player.damage += 1;
        leveling.need *= 2;
        dmg += 1;
        damager.text = "Damage lvl." + dmg;
        GameStateManager.Instance.SetState(GameState.Playing);
    }
    public void Speed()
    {
        player.speed += 1;
        leveling.need *= 2;
        sp += 1;
        speeder.text = "Speed lvl." + sp;
        GameStateManager.Instance.SetState(GameState.Playing);
    }

    
}
