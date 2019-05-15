using UnityEngine;
using System.Collections;

// TODO: Deprecated
// Weak Object Destroy Collision
public class WeakBlockDestroy : MonoBehaviour
{
	void Update()
	{
		HandleDestruction();
	}
		
	void OnTriggerEnter(Collider collider)
	{
		if(!mDestructionActivated && LayerMaskUtil.ContainsLayer(mDestroyLayerMask, collider.gameObject.layer))
		{
			mDestructionTime = Time.time + 1;
			mDestructionActivated = true;
		}
	}

	protected void HandleDestruction()
	{
		if(mDestructionActivated && mDestructionTime < Time.time)
			Destroy(gameObject.transform.root.gameObject);
	}
	
	public LayerMask mDestroyLayerMask;

	protected float mDestructionTime;
	protected bool mDestructionActivated;
}
