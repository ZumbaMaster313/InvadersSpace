using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownB : MonoBehaviour {

    public Transform Enemy;
    public Transform endPoint;
    public Transform ForceField;
    public Transform knowPoint;
    // Use this for initialization
    bool _goBackToStart = false;
    bool _checkEnemy = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Making the NavPoint Move
        if (Enemy.transform.position == new Vector3(0, 8, 0))
        {
            _checkEnemy = true; //checks if the forcefeild and player are above refPoint
        }
        if (_checkEnemy == true)
        {
            var _moveUp = new Vector3(0, 9, 0);
            this.transform.Translate(_moveUp);
            _checkEnemy = false;//Moves the Enemy
        }
        if (_checkEnemy == false)
        {
            //Makes the enemy move down
            if (Enemy.transform.position.x >= this.transform.position.x)
            {
                this.transform.position += new Vector3(0, -0.6f, 0) * Time.deltaTime;
            }
            //Returns the enemy back to old position
            if (_goBackToStart == true)
            {
                var _moveBack = new Vector3(0, 10, 0);
                this.transform.Translate(_moveBack);
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
        }
    }
}
