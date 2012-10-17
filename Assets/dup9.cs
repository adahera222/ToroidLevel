using UnityEngine;
using System.Collections;

public class dup9 : MonoBehaviour {
	
	public GameObject targetObject;
	 GameObject[] dup;
	
	// Use this for initialization
	void Start () {
		dup = new GameObject[9];
		
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		
		for(int i=0;i<3;i++){
			for(int j=0;j<3;j++) {
				//clone all but the one that already exists
				if ( !(i==1 && j==1) ) {
					int index = i*3+j;
					dup[index] = (GameObject)Instantiate(targetObject);
					float xadder = (j-1)*Screen.width;
					float yadder = (i-1)*Screen.height;
					print(xadder + " " + yadder);
					Vector3 newScreenPos = new Vector3(screenPos.x+xadder,screenPos.y+yadder,screenPos.z);
					dup[index].transform.position = Camera.main.ScreenToWorldPoint(newScreenPos);
				}

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
}
