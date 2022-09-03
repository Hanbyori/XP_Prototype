using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	MeshRenderer render;
	GameObject col;

	public GameObject bullet;
	public Transform fire;

	public GameObject img;

	bool isAbs = false;
	public string type = "";

	float speed;
	float hAxis;
	float vAxis;

	Vector3 move;

	private void Start()
	{
		speed = Master.instance.playerSpeed;
		render = gameObject.GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		hAxis = Input.GetAxisRaw("Horizontal");
		vAxis = Input.GetAxisRaw("Vertical");

		move = new Vector3(hAxis, 0, vAxis).normalized;

		transform.position += move * speed * Time.deltaTime;
		transform.LookAt(transform.position + move);

		if (Input.GetKeyDown(KeyCode.LeftShift) && isAbs == true)
		{
			if (col.name == "Red")
			{
				type = "red";
				img.SetActive(true);
				speed = Master.instance.playerSpeed;
				render.material.color = Color.red;
			}
			else if (col.name == "Blue")
			{
				type = "blue";
				img.SetActive(false);
				speed = Master.instance.playerSpeed / 2;
				render.material.color = Color.blue;
			}
			else if (col.name == "Green")
			{
				type = "green";
				img.SetActive(false);
				speed = Master.instance.playerSpeed;
				render.material.color = Color.green;
			}
			Debug.Log("Destroy");
			Destroy(col);
		}

		else if (Input.GetMouseButtonDown(0))
		{
			if (type == "red")
			{
				Instantiate(bullet, fire.position, fire.rotation);
			}
			else if (type == "blue")
			{
				Instantiate(bullet, fire.position, fire.rotation);
			}
			else if (type == "green")
			{
				Instantiate(bullet, fire.position, fire.rotation);
			}

		}

		else if (Input.GetMouseButtonDown(1))
		{
			type = "";
			img.SetActive(false);
			speed = Master.instance.playerSpeed;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Abs")
		{
			Debug.Log("Enter");
			col = other.transform.parent.gameObject;
			isAbs = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Abs")
		{
			if(type == "green")
			{
				Debug.Log("µµÆ®µ©!!");
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Abs")
		{
			Debug.Log("Exit");
			isAbs = false;
		}
	}
}
