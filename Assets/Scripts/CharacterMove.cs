using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private float deltaX;
    private float deltaY;

    private Rigidbody2D rb;

    bool moveAllowed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        moveAllowed = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    }
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    break;
            }
        }
    }

}
