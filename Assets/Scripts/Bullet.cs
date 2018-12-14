using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //пуля реализована без пула объектов для примера

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float lifeTime = 1.0f;

    private Vector3 direction = Vector3.up;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponent<Unit>();

        if(unit is Ball)
        {
            Destroy(gameObject);
        }
    }
}
