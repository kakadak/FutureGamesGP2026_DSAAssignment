using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public GameObject stats;
    public GameObject hit;
    public GameObject pause;
    
    public Image hero;

    public float speed = 20f;
    public Sprite[] idle;
    public Sprite[] running;
    public Sprite[] attacking;
    
    public float posx;
    public float posy;
    public float posz;
    public bool isAttacking = false;

    public float frameRate;
    public float attackFrameRate;
    private int currentIdleFrame = 0;
    private int currentRunFrame = 0;
    private int currentAttackFrame = 0;
    private float timer = 0f;
    
    public AudioSource playerAttack;

    public int damage = 1;   
    public Vector3 starting;


    void Start()
    {
        starting = player.transform.position;

    }

    void Update()
    {
        if (!GameStateManager.Instance.IsPlaying()) 
        {
            return;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isAttacking)
        {
            isAttacking = true;
            currentAttackFrame = 0;
            timer = 0f;
        }

        if (isAttacking)
        {
            Attack();
            return;
        }

        posz = player.transform.position.z;
        posx = player.transform.position.x;
        posy = player.transform.position.y;
        float sposx = stats.transform.position.x;
        float sposy = stats.transform.position.y;
        float sposz = stats.transform.position.z;
        float pposx = pause.transform.position.x;
        float pposy = pause.transform.position.y;
        float pposz = pause.transform.position.z;
        bool isMoving = false;

        if (Keyboard.current.wKey.isPressed)
        {
            
            posy += speed * Time.deltaTime;
            sposy += speed * Time.deltaTime;
            pposy += speed * Time.deltaTime;
            isMoving = true;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            posy -= speed * Time.deltaTime;
            sposy -= speed * Time.deltaTime;
            pposy -= speed * Time.deltaTime;
            isMoving = true;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            posx -= speed * Time.deltaTime;
            sposx -= speed * Time.deltaTime;
            pposx -= speed * Time.deltaTime;
            isMoving = true;
        }
        if (Keyboard.current.dKey.isPressed)
        {


            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            posx += speed * Time.deltaTime;
            sposx += speed * Time.deltaTime;
            pposx += speed * Time.deltaTime;
            isMoving = true;
        }

        player.transform.position = new Vector3(posx, posy, -1);
        cam.transform.position = new Vector3(posx, posy, -50);
        stats.transform.position = new Vector3(sposx,sposy,sposz);

        if (isMoving)
        {
            Run();
        }
        else
        {
            Idle();
        }
    }

    public void Run()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentRunFrame = (currentRunFrame + 1) % running.Length;
            hero.sprite = running[currentRunFrame];
        }
    }

    public void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentIdleFrame = (currentIdleFrame + 1) % idle.Length;
            hero.sprite = idle[currentIdleFrame];
        }
    }

    public void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= attackFrameRate)
        {
            timer -= attackFrameRate;
            currentAttackFrame++;

            if (currentAttackFrame == 2)
            {
                hit.SetActive(true);
                playerAttack.Play();
            }

            if (currentAttackFrame >= attacking.Length)
            {
                hit.SetActive(false);
                isAttacking = false;
                currentAttackFrame = 0;
            }
            else
            {
                
                hero.sprite = attacking[currentAttackFrame];
            }
        }
    }

}