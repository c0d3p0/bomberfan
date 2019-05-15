using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBombLightBlink : NormalLightBlink
{
	void Start()
	{
		mLight = GetComponent<Light>();
		mLightOnIntensity = mLight.intensity;
		mActivationTime = GetComponentInParent<ActivationBomb>().ActivationTime;
	}

	protected override void ChangeBlinkSpeed()
	{
		if(mActivationTime <= Time.time)
			mBlinkTimeInterval = mActivatedBlinkSpeed;
	}

	public float mActivatedBlinkSpeed = 0.3f;

	protected float mActivationTime;
}
