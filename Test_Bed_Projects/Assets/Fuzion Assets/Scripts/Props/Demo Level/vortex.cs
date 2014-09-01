using UnityEngine;
using System.Collections;

public class vortex : MonoBehaviour {
	
	//Timer used to produce light flickering effect
	double   lightTimer = 0;
		
	// Update is called once per frame
	void FixedUpdate () {
		
		if(lightTimer%2 == 0)
		{
			this.enabled = false;
		}
		if(lightTimer%3 == 0)
		{
			//this.enabled = true;
		}
			
		
		if(lightTimer%100 == 0)
		{
		//	lightTimer =0;
		}
		
		lightTimer = lightTimer + Time.deltaTime*100;
		print (lightTimer);
	}
}
