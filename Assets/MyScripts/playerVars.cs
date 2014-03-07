using UnityEngine;
using System.Collections;

public static class playerVars{
	public static bool canMove;
	public static void EnableMovement(){
		canMove = true;
	}
	public static void DisableMovement(){
		canMove = false;
	}


	public static bool ActiveGUI;
	public static void EnableGUI(){
		ActiveGUI = true;
	}
	public static void DisableGUI(){
		ActiveGUI = false;
	}

	public static bool reachedDestination;
	public static void atDestination(){
		reachedDestination = true;
	}
	public static void goinToDestination(){
		reachedDestination = false;
	}

	public static int textIndex;
	public static void proceed(){
		textIndex++;
	}
	public static void setIndex(int index){
		textIndex = index;
	}

	public static GameObject focusPoint;
	public static void setFocus(GameObject focus){
		focusPoint = focus;
	}

}
