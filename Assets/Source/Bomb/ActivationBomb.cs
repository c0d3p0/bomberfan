using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBomb : Bomb
{
	protected override void OnStart()
	{
		mActivationTime = Time.time + mActivationDuration;
	}

	protected override void OnUpdate()
	{
		HandleActivation();
	}

	public float ActivationTime
	{
		get
		{
			return mActivationTime;
		}
	}

	protected void HandleActivation()
	{
		if(!mActivated)
		{
			if(Time.time > mActivationTime)
				mActivated = true;
		}
	}

	public bool Activated
	{
		get
		{
			return mActivated;
		}
	}
		
	public float mActivationDuration = 1f;

	protected float mActivationTime;
	protected bool mActivated;
}
