using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 0.1f;

    private Rigidbody2D rb2d;

    private bool movingLeft;
    private bool movingRight;


    // Use this for initialization
    void Start()
    {

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        movingLeft = true;
        movingRight = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = 0;

        //Checks to see if moving left
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a")
            || ((Input.GetKeyUp("right") || Input.GetKeyUp("d") || Input.GetKeyUp("up") || Input.GetKeyUp("w") || Input.GetKeyUp("down") || Input.GetKeyUp("s"))
                && (Input.GetKey("left") || Input.GetKey("a"))))
        {
            movingLeft = true;
            movingRight = false;
        }

        //Checks to see if moving right
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d")
            || ((Input.GetKeyUp("left") || Input.GetKeyUp("a") || Input.GetKeyUp("up") || Input.GetKeyUp("w") || Input.GetKeyUp("down") || Input.GetKeyUp("s"))
                && (Input.GetKey("right") || Input.GetKey("d"))))
        {
            movingLeft = false;
            movingRight = true;
        }


        if (movingLeft || movingRight)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
        }


        //Store movement in a 2d vector
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //move the player
        rb2d.MovePosition(rb2d.position + movement * speed * Time.deltaTime);
    }

}