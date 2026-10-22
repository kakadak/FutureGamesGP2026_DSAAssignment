using UnityEngine;

public class PlayerDMG : MonoBehaviour
{
    public PlayerHP heal;
    public AudioSource auone;
    public AudioSource autwo;
    private float damageTimer = 0f;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameStateManager.Instance.IsPlaying()) return;

        if (collision.gameObject.CompareTag("enemy"))
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                heal.health -= 5;
                damageTimer = 1f; 
                if (!auone.isPlaying) auone.Play();
            }
        }
        if (collision.gameObject.CompareTag("bigenemy"))
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                heal.health -= 5;
                damageTimer = 1f; 
                if (!autwo.isPlaying) 
                {
                autwo.Play();
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!GameStateManager.Instance.IsPlaying()) return;

        if (collision.gameObject.CompareTag("enemy"))
        {
            damageTimer = 0f;
        }
        if (collision.gameObject.CompareTag("bigenemy"))
        {
            damageTimer = 0f;
        }
    }
}