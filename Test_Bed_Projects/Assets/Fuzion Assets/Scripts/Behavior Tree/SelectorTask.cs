using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectorTask : Task {
	Queue<Task> child_queue;

	
	public SelectorTask(BehaviorTree parentTree):base(parentTree)
	{
		child_queue = new Queue<Task> ();
	}



	public bool	run()
	{
		do
		{
			Task tChild = child_queue.Dequeue();
			if (tChild.run())
			{
				return true;
			}
		 }
		while(child_queue.Count >0);
	
	 return false;
	}

}
