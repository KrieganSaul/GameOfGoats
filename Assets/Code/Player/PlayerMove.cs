/*======================================================================
 * Player Move
 * 
 * Description: This class moves the player front, back, left, and 
 * right. It also includes the jump movement. It does not rotate
 * the player. This code will go on the actual player object.
 * ====================================================================*/

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 5;
	
	public float jumpSpeed =  17.0F;
	public float maxJump = 9.0F;
	
	
	private bool jumpState;
	private bool canJump;
	private float groundedYPos;
	
	
	private CharacterController cController;

	
	void Start () {
		cController = GetComponent<CharacterController> ();
		canJump = true;
		jumpState = false;
		groundedYPos = transform.position.y;
		
	}
	
	void Update () {
	
			Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), jump(), Input.GetAxis("Vertical"));
			
			moveDir = transform.TransformDirection(moveDir);
			
			cController.Move(moveDir*speed*Time.deltaTime);
			
}
	
	
	float jump() {
		float deltaY = -1;
		
		if (jumpState)
		{
			if (Input.GetButton("Jump") && (transform.position.y < (groundedYPos+maxJump) && cController.velocity.y > 0))
			deltaY = 1;
			
			else
			{
				jumpState = false;
				deltaY = -1;
			}			
			
			if(cController.isGrounded)
			{
				jumpState = false;
				deltaY = 0;
				groundedYPos = transform.position.y;
			}
		}
		
		if  (cController.isGrounded && !(Input.GetButton("Jump")))
		{
			canJump = true;
			groundedYPos = transform.position.y;
			
		}
		
		//clean up at the end in order to reset the jump state. This may work better someplace above.
		if (cController.isGrounded && Input.GetButton("Jump") && canJump)
		{
			jumpState = true;
			canJump = false;
			groundedYPos = transform.position.y;
			deltaY = 1;
		
		}
		return deltaY;

	}

	
	
}