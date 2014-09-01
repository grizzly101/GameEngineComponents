using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateGraph {

	public string 			state_graph_name;
	public List<iState> 	state_list;

	//Accessed by its nodes to publish their transition decisions
	//Key = node name: value = transition name.  The state graph informs the sm of transitions
	//public Dictionary<int,int> publish_transistion_request;
	

}
