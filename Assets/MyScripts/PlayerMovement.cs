using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//TODO: BREAK INTO MOVE AND CAMERA....also fix jenky GUI select thing


	//Camera Parameters
	public Camera playerCam;
	public float CamSpeed;
	public float cameraDistance;

	//Movement Parameters
	public float PlayerSpeed;
	public float jumpStrength;
	bool canJump;
	public float gravity;

	//avatar
	public GameObject avatar;
	Vector3 avatarPos;

	public bool canMove;

	private bool paused = false;
	
	void Start () {
		canMove = false;
		//set initial position of camera and player
		Physics.gravity = new Vector3(0,gravity * -1,0);
		transform.position.Set(0,3,0);
		playerCam.transform.position = new Vector3(15,0,15);

	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused){
				Time.timeScale = 1;
				paused = false;
			}else{
				paused = true;
				Time.timeScale = 0;
			}
			//StartCoroutine(pause());
		}
		//make the camera look at the player
		playerCam.transform.LookAt(transform);

		//Movement controls
		if (canMove) {
			playerMove ();
			cameraMove ();
		}

		//Adjust movement direction to point away from camera
		Vector3 cameraPos = transform.position - playerCam.transform.position;
		cameraPos.y = 0;
		Quaternion playerCoreRotate = Quaternion.LookRotation(cameraPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, playerCoreRotate, Time.deltaTime * 10f);
		
		//Ensure camera is near the player
		holdCamera();

		//Snap avatar to player position
		avatar.transform.position = transform.position - Vector3.up * 13;
	}

	IEnumerator pause(){
		bool paused = true;
		print("routine");
		yield return new WaitForSeconds(1f);
		while (paused) {

			if (Input.GetKey(KeyCode.Escape)) {
				print ("YEAH BUDDY");
				paused = false;
			}else{
				print("I'm paused");
			}

		}
		yield return null;

	}

	
	void playerMove(){
		//Player Movement With WASD
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed);
			playerCam.transform.Translate(transform.forward * Time.deltaTime * PlayerSpeed, Space.World);
			avatarPos = avatar.transform.position - playerCam.transform.position;
			avatarPos.y = 0;
			Quaternion rotation = Quaternion.LookRotation(avatarPos);
			avatar.transform.rotation = Quaternion.Slerp(avatar.transform.rotation, rotation, Time.deltaTime * 10f);
			avatar.transform.GetChild(0).transform.Rotate(0,1,0);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(-Vector3.forward * Time.deltaTime * PlayerSpeed);
			playerCam.transform.Translate(-1 * transform.forward * Time.deltaTime * PlayerSpeed,Space.World);
			
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * Time.deltaTime * PlayerSpeed);
			playerCam.transform.Translate(-1 * transform.right * Time.deltaTime * PlayerSpeed,Space.World);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(-Vector3.left * Time.deltaTime * PlayerSpeed);
			playerCam.transform.Translate(transform.right * Time.deltaTime * PlayerSpeed, Space.World);
		}		
	}

	void cameraMove(){
	
		//Camera Motion With Arrow Keys

		if(Input.GetKey(KeyCode.UpArrow)){
			playerCam.transform.RotateAround(transform.position,playerCam.transform.right,1 * CamSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			playerCam.transform.RotateAround(transform.position,playerCam.transform.right,-1 * CamSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			playerCam.transform.RotateAround(transform.position,transform.up,1 * CamSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			playerCam.transform.RotateAround(transform.position,transform.up,-1 * CamSpeed * Time.deltaTime);			
		}	
	
		if(Input.GetAxis("Mouse Y") != 0){
			playerCam.transform.RotateAround(transform.position,playerCam.transform.right,Input.GetAxis("Mouse Y") * -1 * CamSpeed * Time.deltaTime);
		}
		if(Input.GetAxis("Mouse X") != 0){
			playerCam.transform.RotateAround(transform.position,transform.up,Input.GetAxis("Mouse X") * CamSpeed * Time.deltaTime);
		}
	

	}
	
	void holdCamera(){
		//Camera Distance Control
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			cameraDistance++;	
		}
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			cameraDistance--;	
		}
		if(Vector3.Distance(transform.position, playerCam.transform.position) > cameraDistance + 1){
			playerCam.transform.position -= (playerCam.transform.position-transform.position) * .01f;	
		}
		if(Vector3.Distance(transform.position, playerCam.transform.position) < cameraDistance - 1){
			playerCam.transform.position += (playerCam.transform.position-transform.position) * .01f;	
		}
	}
	
	
	void FixedUpdate(){
		if(Input.GetKeyDown(KeyCode.Space) && canJump){
			canJump = false;
			rigidbody.velocity = new Vector3(0, jumpStrength,0);
		}
	}
	
	void OnCollisionStay(Collision collision){
		if(collision.transform.tag == "jump surface"){
			canJump = true;	
		}
	}
}
