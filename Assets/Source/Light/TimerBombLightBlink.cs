using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBombLightBlink : NormalLightBlink
{
	protected override void ChangeBlinkSpeed()
	{
		if(mLight.intensity == mLightOffIntensity)
		{
			if(mBlinkTimeInterval > 0.01f)
				mBlinkTimeInterval -= mDecreaseBlinkTimeInterval;
		}
	}

	public float mDecreaseBlinkTimeInterval = 0.007f;
}
