using UnityEngine;
using System.Collections;



public class State {

	//Core State Parameters	
	int    state_id;
	float  state_timer;
	string enter_animation;
	string exit_animation;
	string state_animation;
	bool   state_finished;

	public delegate void StateMethod();

	//Handler functions for processing the state
	public StateMethod on_enter;
	public StateMethod on_exit;
	public StateMethod on_process;
		
	public State(int id)
	{
		state_id = id;
		state_finished = false;
		state_timer = 0;
		on_enter = null;
		on_exit = null;
		on_process = null;
		
	}
	public void setFunctions(StateMethod enter, StateMethod exit, StateMethod process)
	{
		on_enter = enter;
		on_exit = exit;
		on_process = process;
	}
	
	public int getID()
	{
		return state_id;
	}
	public string getExit()
	{
		return exit_animation;
		
	}
	public string getEnter()
	{
		return enter_animation;
	}
	public string getState()
	{
		return state_animation;
	}
	public void setTimer(float timerAmt)
	{
		state_timer = timerAmt;
	}
	public float getTimer()
	{
		return state_timer;
	}
	public float decTimer(float dec)
	{
		return state_timer = state_timer - dec;
	}
	public void setFinished()
	{
		state_finished = true;
	}
	public bool getFinFlag()
	{
		return state_finished;
	}

}
