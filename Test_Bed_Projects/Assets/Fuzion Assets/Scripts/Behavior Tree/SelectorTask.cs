using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectorTask : Task {

	public List<Task> child_list;

	
	public SelectorTask(BehaviorTree parentTree):base(parentTree)
	{
		child_list = new List<Task> ();
	}



	public override bool	run()
	{
		Debug.Log ("SelectorTask.Run()");
		foreach(Task tChild in child_list)
		{
			if (tChild.run())
			{
				Debug.Log ("SelectorTask.Child.Run()");
				return true;
			}
		 }
			
	 return false;
	}

}
