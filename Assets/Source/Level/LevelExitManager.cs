using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExitManager : MonoBehaviour
{
	protected void OnTriggerEnter(Collider collider)
	{
		if(LayerMaskUtil.ContainsLayer(mPlayerMask, collider.gameObject.layer))
		{
			// TODO: Code the win pose here
			LevelChangeManager.ChangeLevel();
		}
	}

	public LayerMask mPlayerMask;
}
