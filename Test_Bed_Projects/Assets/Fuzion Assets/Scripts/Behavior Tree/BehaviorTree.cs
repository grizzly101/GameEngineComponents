using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviorTree {

	public FrogCognition  cog_model;

	public List<Task> task_tree;


	public BehaviorTree(FrogCognition cogModel)
	{
		cog_model = cogModel;

		task_tree = new List<Task> ();
	}

}
