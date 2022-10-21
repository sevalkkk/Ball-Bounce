using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;

    bool gameStarted=false;
    public GameObject skillPrefab;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                StartBounce();
                gameStarted = true;
                GameManager.instance.GameStart();
                
            }
        }
       
    }

    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-3, 3), 1);

        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="fallCheck")
        {
            GameManager.instance.Restart();
        }

        else if(collision.gameObject.tag =="paddle")
        {
            GameManager.instance.ScoreUpdate();
        }

        else if(collision.gameObject.tag == "trap")
        {
            collision.gameObject.SetActive(false);
        }

        else if(collision.gameObject.tag =="extra")
        {
            Instantiate(skillPrefab, collision.gameObject.transform.position,Quaternion.identity);
            StartBounce();
            collision.gameObject.SetActive(false);
        }

         
    }

   




}
