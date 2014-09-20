using UnityEngine;
using System.Collections;

public class FrogTalkDecorator : DecoratorTask {
	
	public FrogTalkDecorator(BehaviorTree parentTree):base(parentTree)
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
