using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceTask : Task {

	public List<Task> child_list;
	
	
	public SequenceTask(BehaviorTree parentTree):base(parentTree)
	{
		child_list = new List<Task> ();
	}
	
	
	
	public bool	run()
	{
		foreach(Task tChild in child_list)
		{

			if ((tChild.run()))
			{
				return false;
			}
		}
			
	  return true;
	}
}
