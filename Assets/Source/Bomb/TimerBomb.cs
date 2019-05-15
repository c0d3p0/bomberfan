using UnityEngine;
using System.Collections;

public class TimerBomb : Bomb
{
	protected override void OnStart()
	{
		mExplodeTime = Time.time + 2f;
	}

	protected void HandleExplodeTimer()
	{
		if(mExplodeTime <= Time.time)
			mDetonationActivated = true;
	}

	protected override void OnUpdate()
	{
		HandleExplodeTimer();
	}

	protected float mExplodeTime;
}
