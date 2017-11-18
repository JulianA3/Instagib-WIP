
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShooting : MonoBehaviour {
	

	public Transform impact;
	public float distance = 100f;
	public Transform cover;
	public GameObject shot;
	public GameObject spawnPoint;
	public float firerate = 0.5f;
	private bool allowfire = true;
	//Sets the boolean allow fire to be checked/true

	void Update () {
		RaycastHit hit;

		Vector3 up = Camera.main.transform.forward;

		//Sets the direction of the variable up, usefull because shortenned.
		//Declares variable hit.    

		//Vizualizes the ray(draws) so you can see it.

		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){

		
			//Checks if ray we casted hit an object (distance is the length of a ray).

			if(Input.GetMouseButton(0)&&(allowfire)){
				//Checks if we pressed left mouse button, and if the boolean allow fire is checked.
				//if so:



				Instantiate(impact, hit.point, transform.rotation);
				//It spawns impact Transform on the position of the collision of ray and object.

				Instantiate (shot, spawnPoint.transform.position, transform.rotation);

				StartCoroutine(Fake());
				//Calls function Fake.

			}
		}
	}
	private IEnumerator Fake(){

		allowfire = false;
		//Sets the boolean fire to be unchecked.
		Instantiate(cover, transform.position, transform.rotation);
		//Spawns cover Transform on the position of the object that the script is attached to.
		yield return new WaitForSeconds(firerate);
		//It Waits for the amount of seconds that are stated in the firerate float, before it continues calling the script. 
		allowfire = true;
		//Sets the boolean fire to be checked.
	}
}
