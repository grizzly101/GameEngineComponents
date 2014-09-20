using UnityEngine;
using System.Collections;

public class FrogAnimDecorator : DecoratorTask {

	public FrogAnimDecorator(BehaviorTree parentTree):base(parentTree)
	{
	}

	public bool	run()
	{
				
		if (child_task.run ()) {
			return true;
		} else
			return false;
		
		
	}
}
