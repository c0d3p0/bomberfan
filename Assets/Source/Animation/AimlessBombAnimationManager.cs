using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimlessBombAnimationManager : BaseAnimationManager
{
	protected void Start()
	{
		mBomb = GetComponentInParent<AimlessBomb>();
	}

	protected override void Update()
	{
		HandleAttributes();
		HandleRotation();
	}

	protected void HandleAttributes()
	{
		switch(mBomb.MoveDirectionIndex)
		{
			case 0:
				SetMoveFlags(true, false, false, false);
				break;
			case 1:
				SetMoveFlags(false, true, false, false);
				break;
			case 2:
				SetMoveFlags(false, false, true, false);
				break;
			case 3:
				SetMoveFlags(false, false, false, true);
				break;
		}
	}

	protected AimlessBomb mBomb;
}
