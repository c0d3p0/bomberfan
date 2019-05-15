using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Deprecated
public class CarWheelRotation : MonoBehaviour
{
	void Start ()
	{
		mRadius = GetComponentInChildren<SphereCollider>().radius;
		mVelocity = GetComponentInParent<CharacterController>().velocity;
	}

	void Update ()
	{

	}

	// Distance = Velocity * Time
	// Circunference = 2 * pi * Radius
	// Times to Rotate = Distance / Circunference
	// Angle = Times to Rotate * 360
	protected void RotateWheel(float deltaTime)
	{
		float distance = 0;

		if(mVelocity.x > mVelocity.z)
			distance = deltaTime * mVelocity.x;
		else
			distance = deltaTime * mVelocity.z;

		float rotationAngle = (distance / (2 * Mathf.PI * mRadius) * 360);

//		transform.Rotate();
	}

	protected Vector3 mVelocity;
	protected float mRadius;
}
