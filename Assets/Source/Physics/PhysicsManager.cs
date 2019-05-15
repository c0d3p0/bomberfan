using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
	void Awake()
	{
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer(LayerName.PLAYER_PHYSIC_BOX), LayerMask.NameToLayer(LayerName.ENEMY_PHYSIC_BOX));
	}
}
