using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    [SerializeField] private int lives = 3;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 3)
            {
                lives = value;
                livesPanel.Refresh();
            }
        }
    }

    private LivesPanel livesPanel;
    private SceneController sceneController;

    private Bullet bullet;
    public static float attackSpeed = 0.1f;

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    private float lastShootTime;

    private void Awake()
    {
        livesPanel = FindObjectOfType<LivesPanel>();
        sceneController = FindObjectOfType<SceneController>();
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Update()
    {
        Shoot();
        if (lives == 0)
        {
            Die();
            sceneController.GameOver();
        }
    }

    private void Shoot()
    {
        if (Time.time > lastShootTime + attackSpeed)
        {
            Vector3 position = transform.position; position.y += 0.5f;
            Instantiate(bullet, position, bullet.transform.rotation);

            lastShootTime = Time.time;
        }
    }

    public override void ReceiveDamage()
    {
        Lives--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();

        if(unit is Ball)
        {
            ReceiveDamage();
        }
    }
}
