using UnityEngine;
using System.Collections;

public class FrogTalkTask : Task {

	// Use this for initialization
	public FrogTalkTask(BehaviorTree parentTree):base(parentTree)
	{

	}

	public bool run()
	{
		return true;
	}
}
