//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public struct FuzionIntTuple
{
	string key;
	int    value;
}

public class iTransition : FuzionEventArg
{



	int from_stateID;
	int to_stateID;

	List<FuzionIntTuple> args;

	public iTransition(int from_stateID,int to_stateID, List<FuzionIntTuple> _args)
	{
		args = _args;
	}
}


