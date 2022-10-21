using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public GameObject ballPrefab;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        TouchMove();
    }
    void TouchMove()
    {

        if(Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(touchPos.x);
            if(touchPos.x < 0)
            {
                rb.velocity = Vector2.left * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "skill")
        {
            GameObject extraBall = Instantiate(ballPrefab, collision.gameObject.transform.position, Quaternion.identity);

            collision.gameObject.SetActive(false);
        }
    }

}
