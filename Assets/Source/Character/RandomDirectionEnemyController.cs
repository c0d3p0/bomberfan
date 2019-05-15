using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirectionEnemyController : BaseController
{
	public int MoveDirectionIndex
	{
		get
		{
			return mMoveDirectionIndex;
		}
	}

	protected int mMoveDirectionIndex;
}
