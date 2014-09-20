using UnityEngine;
using System.Collections;

public class FrogAnimateTask : Task {


	public FrogAnimateTask(BehaviorTree parentTree):base(parentTree)
	{
	}

	public bool run()
	{
		return true;
	}
}
