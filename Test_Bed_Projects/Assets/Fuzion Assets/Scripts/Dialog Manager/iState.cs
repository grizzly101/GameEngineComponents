using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class iState {

	public bool state_process;
	
	public int  state_id;
	public int  next_state_id;

	public List<iTransition> transitions_list;

	public iState()
	{
	}

	public virtual bool inProcess()
	{
		return state_process;
	}
	public 	virtual void onEnter()
	{
	}
	public 	virtual void onExit()
	{
	}
}
