using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClone : MonoBehaviour {

    private float speed = 8f;

    public Transform Bullet;
    public Transform MidPoint;
    public Transform StopPoint;
    public Transform Player;

    bool IsKeyPressed;
    // Use this for initialization
    void Start()
    {
        IsKeyPressed = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        //Makes the Bullet stay with the enemy
        if (IsKeyPressed == false)
        {
            this.transform.position = Player.transform.position;
        }
        //Has the bullet move
        else if (IsKeyPressed == true)
        {
            this.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        //Makes the bullet move back to origional position
        if (this.transform.position.y >= StopPoint.transform.position.y)
        {
            this.transform.position = Player.transform.position;
            IsKeyPressed = false;
        }
        if (Input.GetKeyDown("space"))
        {
            if (Bullet.transform.position.y >= MidPoint.transform.position.y)
            {
                IsKeyPressed = true;
            }
        }

    }
}