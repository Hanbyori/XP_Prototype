using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;
using TMPro;

public class Player : MonoBehaviour
{
	MeshRenderer render;
	GameObject col;

	public GameObject pre_redFlame;
	public GameObject pre_blueFlame;
	public GameObject pre_greenFlame;
	GameObject redFlame;
	GameObject blueFlame;
	GameObject greenFlame;

	TextMeshProUGUI info;

	public Transform fire;
	public GameObject img;

	Vector3 move;

	public int hp = 100;
	public float speed = 5f;
	float hAxis;
	float vAxis;

	bool isAbs = false;
	public string type = "";

	private void Start()
	{
		info = GameObject.Find("info").GetComponent<TextMeshProUGUI>();
		render = gameObject.GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		if (hp <= 0) Destroy(gameObject);

		hAxis = Input.GetAxisRaw("Horizontal");
		vAxis = Input.GetAxisRaw("Vertical");

		move = new Vector3(hAxis, 0, vAxis).normalized;

		transform.position += move * speed * Time.deltaTime;
		transform.LookAt(transform.position + move);

		info.text = "HP : " + hp.ToString() + "\nSpeed : " + speed.ToString() + "\nType : " + type.ToString();

		if (Input.GetKeyDown(KeyCode.LeftShift) && isAbs == true)
		{
			if (col.name == "Red")
			{
				type = "red";
				img.SetActive(true);
				transform.GetChild(2).gameObject.SetActive(false);
				speed = 5f;
				render.material.color = Color.red;
			}
			else if (col.name == "Blue")
			{
				type = "blue";
				img.SetActive(false);
				transform.GetChild(2).gameObject.SetActive(false);
				speed = 3f;
				render.material.color = Color.blue;
			}
			else if (col.name == "Green")
			{
				type = "green";
				img.SetActive(false);
				transform.GetChild(2).gameObject.SetActive(true);
				speed = 5f;
				render.material.color = Color.green;
			}
			Debug.Log("Destroy");
			Destroy(col);
		}

		else if (Input.GetMouseButtonDown(0))
		{
			if (type == "red")
			{
				redFlame = GameObject.Instantiate(pre_redFlame, fire.position, fire.rotation);
				redFlame.transform.parent = gameObject.transform;
			}
			else if (type == "blue")
			{
				blueFlame = GameObject.Instantiate(pre_blueFlame, fire.position, fire.rotation);
				blueFlame.transform.parent = gameObject.transform;
			}
			else if (type == "green")
			{
				greenFlame = GameObject.Instantiate(pre_greenFlame, fire.position, fire.rotation);
				greenFlame.transform.parent = gameObject.transform;
			}

		}

		else if (Input.GetMouseButtonUp(0))
		{
			if (type == "red")
			{
				Destroy(redFlame);
			}
			else if (type == "blue")
			{
				Destroy(blueFlame);
			}
			else if (type == "green")
			{
				Destroy(greenFlame);
			}
		}

		else if (Input.GetMouseButtonDown(1))
		{
			type = "";
			img.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(false);
			render.material.color = Color.white;
			speed = 5f;
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
