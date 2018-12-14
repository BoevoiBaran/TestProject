using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRb;
    [SerializeField] private float minImpulse = 5.0f;
    [SerializeField] private float maxImpulse = 10.0f;


    private void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Unit unit = col.GetComponent<Unit>();

        if(unit && unit is Ball)
        {
            ballRb.AddForce(transform.up * Random.Range(minImpulse, maxImpulse), ForceMode2D.Impulse);
        }
    }
}
