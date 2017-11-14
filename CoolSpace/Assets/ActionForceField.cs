using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionForceField : MonoBehaviour {

	public Transform Enemy;
	public Transform Bullet;
	public Transform endPoint;

	bool DidBulletHitMe;

	public float radius = 1f;
	// Use this for initialization
	void Start()
	{
		DidBulletHitMe = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (DidBulletHitMe == false)
        {
            Enemy.transform.position = this.transform.position;
        }
        else if (DidBulletHitMe == true)
        {
            Enemy.transform.position = new Vector3(0, 9, 0);
            DidBulletHitMe = false;
        }
        if (BulletInRadius())
        {
            DidBulletHitMe = true;
        }
    }
	
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

