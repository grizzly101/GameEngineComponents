using UnityEngine;
using System.Collections;


/*Fuzion Event  Base Class to be inherited by other event classes defined.
 Note that event args do not inherit from Unity's MonoBehaviour.
 This means they cannot be placed on gameobjects, have public
 vars visible in the inspector or use unity events like
 Start(), Update(), FixedUpdate(), etc.*/

public class FuzionEventArg{

	public FuzionEventArg()
	{
		
	}
}
