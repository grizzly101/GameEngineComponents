using UnityEngine;
using System.Collections;

public class DecoratorTask : Task {

	public Task child_task;
	
	
	public DecoratorTask(BehaviorTree parentTree):base(parentTree)
	{
		child_task = null;
	}
	

	
}
