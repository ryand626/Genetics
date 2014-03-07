using UnityEngine;
using System.Collections;

public static class playerVars{
	// Initialization
	public static void initialize () {
		//DisableMovement ();
		//DisableGUI ();
		//setIndex (0);
		//atDestination ();
		setName ("JEFF");
	}

	// Player info
	public static string name;
	public static void setName(string newName){
		name = newName;
	}

	// Movement
	public static bool canMove;
	public static void EnableMovement(){
		canMove = true;
	}
	public static void DisableMovement(){
		canMove = false;
	}

	// GUI
	public static bool ActiveGUI;
	public static void EnableGUI(){
		ActiveGUI = true;
	}
	public static void DisableGUI(){
		ActiveGUI = false;
	}

	// Dialogue Tree
	public static int textIndex;
	public static void proceed(){
		textIndex++;
	}
	public static void setIndex(int index){
		textIndex = index;
	}

	// Pathfinding
	public static bool reachedDestination;
	public static void atDestination(){
		reachedDestination = true;
	}
	public static void goinToDestination(){
		reachedDestination = false;
	}

	// Camera Focus
	public static GameObject focusPoint;
	public static void setFocus(GameObject focus){
		focusPoint = focus;
	}

}
