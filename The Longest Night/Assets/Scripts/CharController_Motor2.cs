using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController_Motor2 : MonoBehaviour {

	public float speed = 10.0f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	//float rotX, rotY;
	float gravity = -9.8f;



	public float SpeedH = 10f;
	public float SpeedV = 10f;
	private static float yaw = 0f;
	private static float pitch = 0f;
	private float minPitch = -30f;
	private float maxPitch = 30f;


	void Start(){
		character = GetComponent<CharacterController> ();
	}


	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}



	void Update(){
		moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;

		yaw += Input.GetAxis("Mouse X") * SpeedH;
		pitch -= Input.GetAxis("Mouse Y") * SpeedV;
		pitch = Mathf.Clamp(pitch, minPitch, maxPitch);


		CheckForWaterHeight ();


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);

		CameraRotation (cam, yaw, pitch);

		if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			movement = transform.rotation * movement;
		}
		character.Move (movement * Time.deltaTime);
	}


	void CameraRotation(GameObject cam, float yaw, float pitch){		
		transform.eulerAngles = new Vector3(pitch, yaw, 0f);
		cam.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
	}




}
