using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 1;
    private float minX, maxX, minY, maxY;
    private float playerRadius;
    public bool player2;
    Rigidbody2D rb;
    public float dashSpeed = 3f;
    private Vector3 offset;
    Vector3 newPosition;
    float mousePositionX,mousePositionY;
    Vector3 paddlePosition;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CapsuleCollider2D playerCollider = GetComponent<CapsuleCollider2D>();
        //BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
        playerRadius = playerCollider.bounds.extents.x;

        // Getting Bottom Corner & Top Corner Of the Screen.
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        // Giving Contrains Accoring to the Screen Size.
        minX = bottomCorner.x + playerRadius + 0.2f;
        maxX = topCorner.x - playerRadius - 0.2f;
        if (!player2)
        { //Upper Half
            minY = bottomCorner.y + playerRadius + 0.2f;
            maxY = 0;
        }
        else
        { //Lower Half
            minY = 0;
            maxY = topCorner.y - playerRadius - 0.2f;
        }

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void Update()
    {
        /* Player Movement */
        /* transform.Translate(Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime,
                            Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime,0f) ;*/

        mousePositionX = Input.mousePosition.x;
        mousePositionY = Input.mousePosition.y;
        

        newPosition = new Vector3(mousePositionX, mousePositionY , 10.0f);
        paddlePosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;
       
         if(Time.timeScale == 1)
        {
            Vector2 moveLocation = new Vector2(-paddlePosition.x,paddlePosition.y);
            transform.position = Vector2.MoveTowards(transform.position,moveLocation,moveSpeed);
        }
           // Horizontal contraint
        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y);
        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y); 

        // vertical contraint
        if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x , minY );
        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY); 
    }

    
   
}
