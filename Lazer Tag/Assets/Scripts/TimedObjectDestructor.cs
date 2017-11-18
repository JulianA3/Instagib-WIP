using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour {
	public float TimeOut = 0.2f;

	
	// Update is called once per frame
	void Update () {
		Destroy(this.gameObject, TimeOut);
	}
}
