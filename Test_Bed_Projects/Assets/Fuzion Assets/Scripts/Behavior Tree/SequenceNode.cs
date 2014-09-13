using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceNode : Task {

	Queue<Task> child_queue;
	
	
	public SequenceNode()
	{
		child_queue = new Queue<Task> ();
	}
	
	
	
	public bool	run()
	{
		do
		{
			Task tChild = child_queue.Dequeue();
			if ((tChild.run()))
			{
				return false;
			}
		}
		while(child_queue.Count >0);
			
	  return true;
	}
}
