using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float sensetivity = 3f;
//	[SerializeField]
	private float Fuel = 1.0f;
	[SerializeField]
	private float thrusterForce = 1000f;

	public Image theBar;


	private PlayerMotor motor;
	private ConfigurableJoint joint;


	void Start ()
	{
		motor = GetComponent<PlayerMotor>();

		theBar.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		Debug.Log ("localscale " + theBar.transform.localScale);

	}


	void Update ()
	{
		Cursor.visible = false;
		StartCoroutine (regenFuel ());

		//calculate movement velocity as a 3D vector
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;
		//final movement vector
		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		//apply movement

		motor.Move(_velocity);

		//calculate rotation as a 3D vector

		float _yRot = Input.GetAxisRaw("Mouse X");


		Vector3 _rotation = new Vector3 (0f, _yRot, 0) * sensetivity;

		motor.Rotate(_rotation);

		//calculate camera rotation as a 3D vector

		float _xRot = Input.GetAxisRaw("Mouse Y");


		float _camRotationX = _xRot * sensetivity;

		motor.RotateCamera(_camRotationX);

		Vector3 _thrusterForce = Vector3.zero;


		if (Input.GetButton ("Jump") && Fuel>=0.05f) {
			
			Fuel -= 0.1f;

			theBar.transform.localScale = new Vector2 (Fuel, 1f);

			_thrusterForce = Vector3.up * thrusterForce;

		} 

		motor.ApplyThruster (_thrusterForce);
	}

	private IEnumerator regenFuel(){
		Debug.Log ("localscale " + theBar.transform.localScale);
		yield return new WaitForSeconds (2f);
		if (Fuel < 1.0f) 
			Fuel += 0.01f;
		Debug.Log ("Fuel " + Fuel);
		theBar.transform.localScale = new Vector3 (Fuel, 1f, 1.0f);

	}



		
}
