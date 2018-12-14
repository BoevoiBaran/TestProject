using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Unit, IPoolable
{
    private int lives;
    public int Lives { get; set; }

    // реализация интерфейса
    [SerializeField] private string poolId = "ball-01";
    public string PoolId
    {
        get
        {
            return poolId;
        }
    }

    [SerializeField] private int objectsCount = 30;
    public int ObjectsCount
    {
        get
        {
            return objectsCount;
        }
    }

    //интерфейс конец
    private bool isImpulsed = false;
    [SerializeField] private float impulse = 1.0f; //импульс который получает шарик падая на землю

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Color colorDefault = Color.white;
    [SerializeField] private Color colorToTurnTo = Color.white; //изменяемое поле чвет которым мигает объект при попадании по нему
    public Sprite[] image; // массив спрайтов из которого объекту рандомно присваивается внешний вид
    [SerializeField] private GameObject starEffect; // система частиц которая спавнится при "убийстве" шара

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        SpriteRandomInst();
        lives = Random.Range(2, 11);
    }

    private void Update()
    {
        if (isImpulsed) Impulse();
        if (lives == 0) Die();
    }

    private void SpriteRandomInst()
    {
        int rand = Random.Range(0, image.Length);
        sprite.sprite = image[rand];
    }


    public override void ReceiveDamage()
    {
        StartCoroutine(ChangeColorOnHit());
        lives--;  
    }

    IEnumerator ChangeColorOnHit()
    {
        sprite.material.color = colorToTurnTo;
        yield return new WaitForSeconds(0.1f);
        sprite.material.color = colorDefault;
    }

    public override void Die()
    {
        Instantiate(starEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject); вместо уничтожения объекта делаем его неактивным и он возвращается в пул
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isImpulsed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isImpulsed = false;
    }

    private void Impulse()
    {
        rb.AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if(bullet)
        {
            ReceiveDamage();
        }
    }

}
