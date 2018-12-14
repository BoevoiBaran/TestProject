using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    //private Ball ball;

    [SerializeField] private string ballId = "ball-01";

    [SerializeField] private float interval = 1.0f; // временной интервал с которым создаются шары
    [SerializeField] private float minX; // смещение координаты точки респауна шаров 
    [SerializeField] private float maxX;

    private void Awake()
    {
        //ball = Resources.Load<Ball>("Ball"); после создания пула объектов нет необходимости подгружать ресурс
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 1.0f, interval);
    }

    private void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(minX, maxX), transform.position.y);

        //Ball b = Instantiate(ball, pos, Quaternion.identity) as Ball; Вместо тяжелого метода инст. берем объект из пула

        Ball b = (Ball)ObjectsPool.Instanse.GetObject(ballId);
        if(!b)
        {
            return;
        }

        b.transform.position = pos;
        b.transform.rotation = Quaternion.identity;

        Debug.Log("Spawn");
        b.gameObject.SetActive(true); // и делаем объект активным
    }

}
