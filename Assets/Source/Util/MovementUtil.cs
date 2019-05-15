using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Deprecated
public class MovementUtil
{
	public static bool ArrivedInDestiny(Vector3 actualPosition, Vector3 destiny, Vector3 moveDirection)
	{
		if(moveDirection.x != 0)
		{
			if(moveDirection.x > 0)
				return actualPosition.x >= destiny.x;
			else
				return actualPosition.x <= destiny.x;	
		}

		if(moveDirection.z != 0)
		{
			if(moveDirection.z > 0)
				return actualPosition.z >= destiny.z;
			else
				return actualPosition.z <= destiny.z;	
		}

		return false;
	}
}
