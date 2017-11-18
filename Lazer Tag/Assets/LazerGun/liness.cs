
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liness : MonoBehaviour {
	
	public GameObject gun;
	public GameObject projectile;

	void Update(){


		gun = GameObject.FindGameObjectWithTag("end");
		//sets the Transform on variable gun to be the object with a tag end.


		LineRenderer lr = gameObject.GetComponent<LineRenderer>();
		//Finds line renderrer on this object. 



		lr.SetPosition(0, gun.transform.position);
		//Sets the 1st position of the line renderrer(end and start position).
		lr.SetPosition(1, projectile.transform.position);
		//Sets the 2nd position of the line renderrer(line renderrer will be drawn beetwen those 2 points(gun, projectile).
	}

	//Script to create laser/line effect beetwen 2 random points.
}
