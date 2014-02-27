using UnityEngine;
using System.Collections;

public static class playerVars{
	public static bool canMove;

	public static void toggle(){
		canMove = !canMove;
	}
}
