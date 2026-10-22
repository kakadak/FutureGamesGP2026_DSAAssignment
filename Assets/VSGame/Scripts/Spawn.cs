using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Spawn : MonoBehaviour
{
    public Transform Game; 
    public GameObject enemy;
    public GameObject bigEnemy;
    public Character player;
    public LVL exp;
    public Timer tim;
    public float spawnRadius = 5f;
    public int maxEnemies = 15;
    public List<GameObject> activeEnemies = new List<GameObject>();
    private float bigEnemyTimer = 0f;
    private float bigEnemyInterval = 6f;
    public AudioSource Nee;
    void Update()
    {
        if (!GameStateManager.Instance.IsPlaying()) return;

        bigEnemyTimer += Time.deltaTime;
        if (bigEnemyTimer >= bigEnemyInterval)
        {
            bigEnemyTimer = 0f;
            if (activeEnemies.Count < maxEnemies)
            {
                SpawnBigEnemy();
            }
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (activeEnemies.Count < maxEnemies)
            {
                SpawnEnemy();
            }
        }
    }
    public void SpawnEnemy()
    {
        float rdAngle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 spawnOffset = new Vector3(Mathf.Cos(rdAngle) * spawnRadius, Mathf.Sin(rdAngle) * spawnRadius, 0f);

        Vector3 spawnPosition = player.player.transform.position + spawnOffset;

        GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity, Game);
        newEnemy.GetComponent<Enemy>().Init(exp, this, tim, player,Nee);
        activeEnemies.Add(newEnemy);
    }
    public void SpawnBigEnemy()
    {
        if (bigEnemy == null) return;

        float rdAngle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 spawnOffset = new Vector3(Mathf.Cos(rdAngle) * spawnRadius, Mathf.Sin(rdAngle) * spawnRadius, 0f);

        Vector3 spawnPosition = player.player.transform.position + spawnOffset;

        GameObject newBigEnemy = Instantiate(bigEnemy, spawnPosition, Quaternion.identity, Game);
        newBigEnemy.GetComponent<BigEnemy>().Init(exp, this, tim, player,Nee);
        activeEnemies.Add(newBigEnemy);
    }
    public void RemoveEnemy(GameObject enemyToRemove)
    {
        if (activeEnemies.Contains(enemyToRemove))
        {
            activeEnemies.Remove(enemyToRemove);
        }
    }
}