using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLightBlink : MonoBehaviour
{
	void Start()
	{
		mLight = GetComponent<Light>();
		mLightOnIntensity = mLight.intensity;
	}

	void Update()
	{
		mSecondsPassed += Time.deltaTime;

		TurnOutLight();
		ChangeBlinkSpeed();
		TurnOnLight();
	}

	protected void TurnOutLight()
	{
		if(mLight.intensity == mLightOnIntensity && mSecondsPassed >= mBlinkTimeInterval)
		{
			mLight.intensity = mLightOffIntensity;
			mSecondsPassed = 0f;
		}
	}

	protected void TurnOnLight()
	{
		if(mLight.intensity == mLightOffIntensity && mSecondsPassed >= mBlinkTimeInterval)
		{
			mLight.intensity = mLightOnIntensity;
			mSecondsPassed = 0f;
		}
	}

	protected virtual void ChangeBlinkSpeed() {}
		
	public float mBlinkTimeInterval = 0.3f;

	protected float mLightOnIntensity;
	protected float mLightOffIntensity = 0f;

	protected float mSecondsPassed = 0f;

	protected Light mLight;
}
