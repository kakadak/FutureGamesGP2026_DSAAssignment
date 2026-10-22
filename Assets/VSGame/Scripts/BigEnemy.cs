using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BigEnemy : MonoBehaviour
{
    public LVL exp;
    public float speed = 6f;
    public Sprite bad;
    public Sprite good;
    public Sprite dead;
    private Transform playerTransform;
    private Spawn spawner;
    private Character playerScript;
    private Timer timerScript;
    private Timer death;
    bool deadtimer = true;
    public float hp = 5;
    private bool tookDamage = false;
    private float hitTimer = 0f;
    private bool isDead = false;
    public AudioSource Nee;

    public void Init(LVL expRef, Spawn spawnerRef, Timer timRef, Character characterRef, AudioSource NeeRef)
    {
        Nee = NeeRef;
        exp = expRef;
        spawner = spawnerRef;
        timerScript = timRef;
        playerScript = characterRef;
        playerTransform = playerScript.player.transform;

        hp = 5 + (timerScript.minutes * 3);
        speed = 6f + (timerScript.minutes * 0.5f);
    }

    void Update()
    {
        if (!GameStateManager.Instance.IsPlaying() || isDead)
        {
            return;
        }

        float diffX = transform.position.x - playerTransform.position.x;
        float playerRotY = playerScript.player.transform.eulerAngles.y;

        bool playerFacingLeft = Mathf.Approximately(playerRotY, 180f);
        bool playerFacingRight = Mathf.Approximately(playerRotY, 0f);

        bool shouldMove = (diffX > 0 && playerFacingLeft) || (diffX < 0 && playerFacingRight);

        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }

        if (!playerScript.isAttacking)
        {
            tookDamage = false;
        }

        if (hitTimer > 0f)
        {
            hitTimer -= Time.deltaTime;
            if (hitTimer <= 0f)
            {
                GetComponent<Image>().sprite = good;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!GameStateManager.Instance.IsPlaying() || isDead) return;

        if (other.CompareTag("Hit"))
        {
            if (playerScript.isAttacking && !tookDamage)
            {
                TakeDamage(playerScript.damage);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        hp -= damage;
        
        tookDamage = true;

        GetComponent<Image>().sprite = bad;
        hitTimer = 0.5f;

        if (hp <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        isDead = true;
        Nee.Play();
        
        exp.experience += 50;
        exp.kills += 1;
        spawner.RemoveEnemy(gameObject);

        GetComponent<Image>().sprite = dead;

        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) 
        {
            col.enabled = false;
        }

        float timer = 1f;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}