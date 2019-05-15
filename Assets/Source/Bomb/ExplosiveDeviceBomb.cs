using UnityEngine;
using System.Collections;

public class ExplosiveDeviceBomb : Bomb 
{
	public override bool Detonate()
	{
		mDetonationActivated = true;
		return true;
	}
}
