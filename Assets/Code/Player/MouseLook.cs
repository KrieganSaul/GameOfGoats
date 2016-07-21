/*======================================================================
 * MouseLook
 * 
 * Description: This class rotates the camera in order to allow the
 * player to look up and down. To use it properly, place this code on
 * a camera which is the child of the player. 
 * ====================================================================*/

using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	private float minimumY;
	private float maximumY;
	
	private float rotationY;
	private float sensitivityY;
	
	private Vector3 moveDirection;
	
	
	void Start ()
	{
		
		Cursor.visible = false;
		
		minimumY = -60F;
		maximumY = 60F;
		
		rotationY = 0F;
		sensitivityY = 15F;
	}
	
	void Update ()
	{
		
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		
			moveDirection = new Vector3(-rotationY,0,0);
			transform.localEulerAngles = moveDirection;
	
	}
	
}//END MouseLook