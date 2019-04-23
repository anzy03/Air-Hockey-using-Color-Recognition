using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    float paddleHit = 3.5f;
//    float wallHit = 0.2f;
//    float diceDrag = 0.1f;
    float velocityMulti = 0.2f;
    float minVelocity = 3.5f;
    Vector2 lastRecordedVelocity;
    CircleCollider2D diceCollider;
    BoxCollider2D[] wallCollider;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        diceCollider = gameObject.GetComponent<CircleCollider2D>();
        
        GameObject[] pWalls = GameObject.FindGameObjectsWithTag("Pwall");
        wallCollider = new BoxCollider2D[pWalls.Length];
        for(int i =0;i<pWalls.Length;i++)
        {
            wallCollider[i] = pWalls[i].GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(diceCollider,wallCollider[i],true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        lastRecordedVelocity = rb.velocity;


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "paddle")
        {
            Vector2 transformVector = transform.position - col.transform.position;
            Vector2 paddleVelocity = velocityMulti * col.relativeVelocity;
            float movingVelocity = col.gameObject.GetComponent<Player>().dashSpeed;
            minVelocity += movingVelocity;
            paddleHit = minVelocity;
            paddleHit = Mathf.Clamp(paddleHit, 0.1f, 3.0f);
            rb.velocity = (transformVector + paddleVelocity) * paddleHit;
        }

        if (col.gameObject.tag == "AIpaddle")
        {
            Vector2 transformVector = transform.position - col.transform.position;
            Vector2 paddleVelocity = velocityMulti * col.relativeVelocity;
            float movingVelocity = col.gameObject.GetComponent<AI>().dashSpeed;
            minVelocity += movingVelocity;
            paddleHit = minVelocity;
            paddleHit = Mathf.Clamp(paddleHit, 0.1f, 3.0f);
            rb.velocity = (transformVector + paddleVelocity) * paddleHit;
        }

        if (col.gameObject.tag == "Vwall")
        {

            Vector2 reflect = Vector2.Reflect(lastRecordedVelocity, col.contacts[0].normal);

            //rb.velocity = reflect.normalized * paddleHit;
            rb.velocity = reflect;
        }
       // Debug.Log(col.gameObject.tag);
    }
}
