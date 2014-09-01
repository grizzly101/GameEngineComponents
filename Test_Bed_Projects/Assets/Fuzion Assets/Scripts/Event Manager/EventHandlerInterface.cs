/*
 * Author: Jason M. Blackford
 * Purpose: This file describes all the interfaces that manage or define event handlers for the Rose Red game.
 * The EventManager must define eachone of these interfaces b/c it is required to be the sole register or listener
 * for all game events.  The interface document also informs developers of what events currently exist in the game.
 * It is also a place where new event handelers must be defined for each new event introduced into the game. Each
 * of these methods defined under the interfaces are delegates in some class most likely pertaining to the choosen
 * name of the interface (i.e. methods under the PlayerEventHandlerInterface correlate to delegates defined in a component or 
 * script attached to the player).
 * */
using System.Collections.Generic;

interface PlayerEventHandlerInterface{



	void DialogEventHandler(FuzionEventArg arg);
	void OpenEventHandler(FuzionEventArg arg);
}

interface AIEventHandlerInterface{
	
	//void DialogEventHandler(DialogEventArg e);
}