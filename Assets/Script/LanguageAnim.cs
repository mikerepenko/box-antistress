using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageAnim : MonoBehaviour {

	private bool isAnim;
	public float speed;

	void Update () {
		if (isAnim) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0f, transform.position.y, transform.position.z), speed * 0.02f);
		} 
		else {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-8f, transform.position.y, transform.position.z), speed * 0.02f);
		}
	}
	public void StartAnim(){
		isAnim = true;
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
	}
	public void StopAnim(){
		isAnim = false;
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
	}
}
