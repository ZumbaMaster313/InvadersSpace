using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadeMovement : MonoBehaviour
{

	//Referenced Game Objects;
    public Transform endPoint;
    public Transform ForceFeild;
    public Transform Bullet;
    public Transform refPoint;
    public Transform SidePointA;
    public Transform SidePointB;

    //Radius size
    public float radius = 1f;
    public float speed = 1f;
    //Parameters
    bool DidBulletHitMe;
    bool MoveEnemy;
    bool _goBackToStart;
    bool didGameStart;
    bool Switch;

    void Start()
    {
        DidBulletHitMe = false;
        MoveEnemy = false;
        _goBackToStart = false;
        didGameStart = true;
        Switch = false;
    }


    // Update is called once per frame
    void Update()
    {
        //Makes this asset move with the refPoint
        if (DidBulletHitMe == false) 
        {
            //Makes the Force Field staying with the enemy
            ForceFeild.transform.position = this.transform.position;
        }
        else if (DidBulletHitMe == true)
        {
            //Makes the ForceFeild Move up with the player
            ForceFeild.transform.position = new Vector3(0, 9, 0);
            DidBulletHitMe = false;
        }
        if (BulletInRadius())
        {
            //uses the method below to make the bool true
            DidBulletHitMe = true;
     
        }
        if (ForceFeild.transform.position == new Vector3(0, 9, 0))
        {
            MoveEnemy = true; //checks if the forcefeild and player are above refPoint
        }
        if (MoveEnemy == true)
        {
            this.transform.position = new Vector3(0, 9, 0); //Moves the Enemy
            MoveEnemy = !MoveEnemy;
        }
        //Makes the enemy do it's normal stuff
        if( MoveEnemy == false)
        {
            //sets a speed for the beginning of the game
           if (didGameStart == true)
            {
                this.transform.position += new Vector3(-6f, -0.6f, 0) *Time.deltaTime;    
            }
            if (this.transform.position.x <= SidePointB.transform.position.x)
            {
                didGameStart = false;
            }
           
            if (_goBackToStart == true)
            {
                var _moveBack = new Vector3(0, 9, 0);
                this.transform.Translate(_moveBack);
                didGameStart = true;
                Switch = false;
                
                
            }
            //Sets the bool to true
            
            if (this.transform.position.y <= endPoint.transform.position.y)
            {
                _goBackToStart = true;
            }
            else if (this.transform.position.y >= endPoint.transform.position.y)
            {
                _goBackToStart = false;
            }
            if (Switch == true)
            {
                this.transform.position += new Vector3(6f, -0.6f, 0) * Time.deltaTime;
                
            }
            if (this.transform.position.x <= SidePointB.transform.position.x)
            {
                Switch = true;
            }

                
            if (Switch == false)
            {
                this.transform.position += new Vector3(-6f, -0.6f, 0) * Time.deltaTime;
                
            }
                if (this.transform.position.x >= SidePointA.transform.position.x)
                {
                    Switch = false;
                }
            
   

        }

    }
    //uses method to check if the bullet is in radius
    bool BulletInRadius()
    {
        var DistanceToBullet = (Bullet.transform.position - this.transform.position).magnitude;
        if (DistanceToBullet <= radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
       
}

