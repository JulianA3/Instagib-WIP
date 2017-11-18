using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {


	public GameObject gun;
	public GameObject projectile;


	void FixedUpdate()
	{

		LineRenderer lr = gameObject.GetComponent<LineRenderer> ();

		lr.SetPosition(0, gun.transform.position);
		lr.SetPosition(1, projectile.transform.position);

	}

}
