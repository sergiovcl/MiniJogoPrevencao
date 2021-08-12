using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamePrevencaoPlayer : MonoBehaviour
{
    //movimentação player
    public float speed = 8f;
    public Rigidbody2D playerRb;
    Vector2 movement;

    //animação
    public Animator anim;

    //Epi player
    public int healthMax = 3;
    public int health;

    //barra de Epi
    public Transform lifeBar;
    public GameObject lifeBarObject;
    private Vector3 lifeBarScale;
    private float lifePercent;
    private float lifeBarScaleMax;

    //hp player
    public int hpMax = 5;
    public int hp;

    //barra life
    public Transform hpBar;
    public GameObject hpBarObject;
    private Vector3 hpBarScale;
    private float hpPercent;
    private float hpBarScaleMax;

    //button fake news
    public GameObject buttonEnable;
    public bool buttonEnableFN;
    public GameObject epis;

    

    void Start()
    {
        health = 1;

        lifeBarScale = lifeBar.localScale;
        lifePercent = lifeBarScale.x / health;
        lifeBarScaleMax = lifePercent * health;

        hp = hpMax;

        hpBarScale = hpBar.localScale;
        hpPercent = hpBarScale.x / hp;
        hpBarScaleMax = hpPercent * hp;

        
        buttonEnable.SetActive (false);
        buttonEnableFN = buttonEnable;


    }

    void UpdateLifeBar()
    {
        if(health >= 0)
        {
            lifeBarScale.x = lifePercent * health;
            lifeBar.localScale = lifeBarScale;
        }
    }

    void UpdateHpBar()
    {
        if(hpPercent * hp > hpBarScaleMax)
        {
            return;
        }

        hpBarScale.x = hpPercent * hp;
        hpBar.localScale = hpBarScale;
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;
        }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime); 
    }

    public void OnDamage()
    {
        if(health >= 1)
        {
            health -= 1;
            UpdateLifeBar();
        }

        if(health >= 0)
        {
            hp -= 1;
        }
        else
        {
            hp -=2;
        }
        UpdateHpBar();
        if(hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Contamined"))
        { 
            collider.gameObject.GetComponent<MiniGamePrevencaoContamined>().DisableContaminated();
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Epi"))
            {
            Destroy(collision.gameObject);
            health += 1;
            UpdateLifeBar();

            }
         if (collision.gameObject.CompareTag("Validade"))
        {
            Destroy(collision.gameObject);
            health -= 1;
            UpdateLifeBar();
            if(health >= 0)
            {
                hp -= 1;
            }
            else
            {
                hp -=2;
            }
            UpdateHpBar();
            if (hp <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
         if (collision.gameObject.CompareTag("Vitoria"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
        }  

        if (collision.gameObject.CompareTag("FakeNews"))
        {
            Destroy(collision.gameObject);
            buttonEnable.SetActive (true);
        }
    }

    private void DisableEpi()
    {
        if(buttonEnableFN == true)
        {
            epis.SetActive (false);
        }
        else
        {
            epis.SetActive (true);
        }
    }

}








