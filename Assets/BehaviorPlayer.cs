using UnityEngine;
using System.Collections;
using System;

public class BehaviorPlayer : MonoBehaviour {
	Rigidbody mRb;
	public float mSpeed = 550;
	public float mRotationSpeed = 55;
	bool mGrounded;
	public KeyCode mJumpKey;
	public bool mLogOn;
	public static string GROUND_TAG = "Platform";

	public int mTargetDirection;
	const int DIRECTION_LEFT = -1;
	const int DIRECTION_NONE = 0;
	const int DIRECTION_RIGHT = 1;

	private float relativeToAbsoluteAngle(float degrees) {
		if (degrees >= 180)
			return 180 - degrees % 180;
		else
			return degrees * -1;	
	}
		
	public void print(string msg) {
		if (mLogOn)
			MonoBehaviour.print (msg);
	}

	void alignSelf(Rigidbody rb) {		
		
		float zRotation = relativeToAbsoluteAngle(rb.transform.eulerAngles.z);

		mTargetDirection = Math.Sign (zRotation) == -1 ? DIRECTION_RIGHT : DIRECTION_LEFT;

		if (mTargetDirection == DIRECTION_RIGHT) {
			//seguir rotango hasta que se pase del max		
			if (zRotation < 0) {
				mRb.AddTorque (Vector3.back * mRotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
			} else {
				mTargetDirection = DIRECTION_LEFT;
			}
		}

		if (mTargetDirection == DIRECTION_LEFT) {
			if (zRotation > 0) {
				mRb.AddTorque (Vector3.forward * mRotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
			
			} else {
				mTargetDirection = DIRECTION_RIGHT;
			}
		}
	}

	// Use this for initialization
	void Start () {
		mRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (mGrounded) 
			alignSelf(mRb);		
		
		if (Input.GetKeyDown (mJumpKey) && mGrounded) {
			jump ();
		}
		print (mGrounded);

	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == GROUND_TAG) 
			mGrounded = true;		
	}
	void OnTriggerExit(Collider c) {
		if (c.gameObject.tag == GROUND_TAG) 
			mGrounded = false;
	}

	void jump() {
		if (Math.Abs (relativeToAbsoluteAngle(mRb.rotation.eulerAngles.z)) < 85) {
			mRb.AddRelativeForce(Vector3.up * mSpeed);	
			mRb.AddRelativeTorque (Vector3.forward * 10);
		}	
	}

	void OnCollisionEnter(Collision c) {		
		
	}
}
	