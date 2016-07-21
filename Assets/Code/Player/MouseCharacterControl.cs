/*======================================================================
 * MouseCharacterControl
 * 
 * Description: This class rotates the player to reposition the forward
 * movement. It does not rotate the head up and down nor does it
 * actually change the position coordinates. This code goes on the
 * actual player object.
 * ====================================================================*/

using UnityEngine;
using System.Collections;

public class MouseCharacterControl : MonoBehaviour {
	
	private float rotationX;

	private float sensitivityX;
	
	private Vector3 moveDirection;
	
	void Start ()
	{
		
		sensitivityX = 15F;
		
		moveDirection = Vector3.zero;
			
		rotationX = 0F;

	}// END START
		
		
	void Update ()
	{
			
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		
			moveDirection = new Vector3(0,rotationX,0);
			
			transform.localEulerAngles = moveDirection;
		
	}//END UPDATE
	
	
}//END MOUSECHARACTERCONTROL