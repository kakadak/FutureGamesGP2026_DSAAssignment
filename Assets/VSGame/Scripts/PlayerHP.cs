using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public Slider HP;
    public int health;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = health;
        
    }
}
