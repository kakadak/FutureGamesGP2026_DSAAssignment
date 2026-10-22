using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float seconds;
    public float minutes;
    public TextMeshProUGUI timing;
    public int enemyhp = 1;
    public Spawn spawner;
    private float spawnTimer = 0f;
    void Update()
    {
        if (!GameStateManager.Instance.IsPlaying()) 
        {
            return;
        }
        seconds += Time.deltaTime;
        spawnTimer += Time.deltaTime; 
        if (spawnTimer >= 3f)
        {
            spawnTimer = 0f; 

            if (spawner.activeEnemies.Count < spawner.maxEnemies)
            {
                spawner.SpawnEnemy();
            }
        }
        if (seconds >= 60f)
        {
            seconds -= 60f;
            minutes += 1f;
            enemyhp *= 2;
        }
        timing.text = string.Format("{0:00}:{1:00}", (int)minutes, (int)seconds);
    }
    public void ResetTimer()
    {
        seconds = 0f;
        minutes = 0f;
        spawnTimer = 0f;
        enemyhp = 1;
        if (timing != null)
        {
            timing.text = "00:00";
        }
    }
}