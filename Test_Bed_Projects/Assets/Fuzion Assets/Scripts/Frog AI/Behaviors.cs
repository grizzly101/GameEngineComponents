using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behaviors : MonoBehaviour {
	
	//Declare the states and their IDs
	enum state_id {IDLE, DIALOG, ACTION};
	FrogState      idle, dialog, action;

	FrogState crnt_state;
	FrogState nxt_state;

	//Store available Behavior Trees
	Dictionary<string,BehaviorTree> sub_tree;


	// Use this for initialization
	void Start () {
		//Define States
		idle   =  new FrogState ((int)state_id.IDLE);
		dialog =  new FrogState ((int)state_id.DIALOG);
		action =  new FrogState ((int)state_id.ACTION);

		//Define Behavior Trees
		sub_tree = new Dictionary<string,BehaviorTree> ();
		//Temporary and for testing only
		AnimateTree idle_animate = new AnimateTree ();
		sub_tree.Add ("animate", idle_animate);

		//Assign behavior trees to states
		idle.crnt_tree = sub_tree ["animate"];
	}
	
	// Update is called once per frame
	void Update()
	{
		if(crnt_state.getID() != nxt_state.getID())
		{
			//Debug.Log("OnEnter");
			crnt_state = nxt_state;
			crnt_state.on_enter();
			
		}
		
		if(crnt_state.getFinFlag() == false)
		{
			//Debug.Log("Process");
			crnt_state.on_process();
		}
		else
		{
			//Debug.Log ("exit");
			crnt_state.on_exit();
		}
	}
}
