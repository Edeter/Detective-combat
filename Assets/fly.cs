using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour {

	[SerializeField] private float step = 20f;
	[SerializeField]private Vector3 Tar;
	[SerializeField]private Vector3 startpos;
	[SerializeField]private float speed,acc;
	[SerializeField] Vector2 aha;
	private Vector2 curPos, lastPos;
	// Use this for initialization
	void Start () {
		startpos = transform.position;
		Vector3	mouse = Input.mousePosition;
		mouse.z = 10;
		mouse = Camera.main.ScreenToWorldPoint(mouse);
		//gameObject.transform.position = mouse;
		Tar = mouse;
	}
	void Update()
	{
	 curPos = transform.position;
     if(curPos == lastPos) {
         Boom();
     }
     lastPos = curPos;
	}
	void FixedUpdate()
	{
		step = speed * Time.deltaTime;
		speed += acc;
		gameObject.transform.position = Vector3.MoveTowards(transform.position, Tar, step);
	}

	/// <summary>
	/// Sent each frame where a collider on another object is touching
	/// this object's collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Punches")
		{
			Boom();
		}
	}

	void Boom()
	{

		//screnshake
		Destroy(gameObject);
	}
}
