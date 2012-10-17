using UnityEngine;
using System.Collections;

public class characterMove : MonoBehaviour {
	
	public float speed = 100.0F;
    public float rotationSpeed = 300.0F;
	
	private float x;
	private float y;
	
	public Camera boundsCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	
    void Update() {
		Vector3 screenPos = boundsCamera.WorldToScreenPoint(transform.position);

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= -1* Time.deltaTime;
        transform.Translate(translation, 0, 0);
        transform.Rotate(0, 0, rotation);
	
		if ( screenPos.x < 0 ) {
			Vector3 newScreenPos = new Vector3(screenPos.x+Screen.width,screenPos.y,screenPos.z);
			transform.position = boundsCamera.ScreenToWorldPoint(newScreenPos);

		} else if ( screenPos.x > Screen.width ) {
			Vector3 newScreenPos = new Vector3(screenPos.x-Screen.width,screenPos.y,screenPos.z);
			transform.position = boundsCamera.ScreenToWorldPoint(newScreenPos);
		}
		

		if ( screenPos.y < 0 ) {
			Vector3 newScreenPos = new Vector3(screenPos.x,screenPos.y+Screen.height,screenPos.z);
			transform.position = boundsCamera.ScreenToWorldPoint(newScreenPos);
		} else if ( screenPos.y > Screen.height ) {
			Vector3 newScreenPos = new Vector3(screenPos.x,screenPos.y-Screen.height,screenPos.z);
			transform.position = boundsCamera.ScreenToWorldPoint(newScreenPos);
		}

		
    }

}
