using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punches : MonoBehaviour {
	[SerializeField] private GameObject pun;
	private Vector3 mouse;
	[SerializeField] private Transform Mother;
	[SerializeField] private GameObject prefab;

	[SerializeField] private Sprite Lewy;
	[SerializeField] private Sprite Prawy;
	private GameObject Fist;
	[SerializeField] private bool prawa = false;

	private float RanX,RanY;

	// Use this for initialization
	void Start () {
		Mother = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Follow();

		if(Input.GetMouseButtonDown(0))
		{
			Punch();
		}

	}

	void Follow()
	{
		mouse = Input.mousePosition;
		mouse.z = 10;
		mouse = Camera.main.ScreenToWorldPoint(mouse);
		gameObject.transform.position = mouse;
	}

	void Punch()
	{	
		Transform Des = Mother;

		RanX = Random.Range(-4.0f, 4.0f);
		RanY = Random.Range(-3.0f, -6.0f);

		//create punch
		//losowo spawniwać rękawice żeby poruszała się w strone myszy
		 Fist = Instantiate(prefab, new Vector3(RanX,RanY,0), Quaternion.identity);
		if (prawa == true)
		{
			prawa = false;
			Fist.GetComponent<SpriteRenderer>().sprite = Lewy;
		}
		if (prawa == false)
		{ 
			Fist.GetComponent<SpriteRenderer>().sprite = Prawy;
			prawa = true;
		}
		
	
		float rot_z = Mathf.Atan2(Des.transform.position.y, Des.transform.position.x) * Mathf.Rad2Deg;
         Fist.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

		


	}
}
