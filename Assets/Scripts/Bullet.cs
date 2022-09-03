using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
	TextMeshPro redscore;
	TextMeshPro bluescore;
	TextMeshPro greenscore;
	public float bulletSpeed = 3f;
	MeshRenderer render;

	string playerType;

	private void Start()
	{
		redscore = GameObject.Find("redscore").GetComponent<TextMeshPro>();
		bluescore = GameObject.Find("bluescore").GetComponent<TextMeshPro>();
		greenscore = GameObject.Find("greenscore").GetComponent<TextMeshPro>();

		render = GetComponent<MeshRenderer>();
		playerType = GameObject.Find("Player").GetComponent<Player>().type;
		if (playerType == "red")
		{
			render.material.color = Color.red;
		}
		else if (playerType == "blue")
		{
			render.material.color = Color.blue;
		}
		else if (playerType == "green")
		{
			render.material.color = Color.green;
		}
		Destroy(gameObject, 3f);
	}

	private void Update()
	{
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "RedT")
		{
			if (playerType == "blue")
			{
				redscore.text = "X1.5";
			}
			else
			{
				redscore.text = "X1.0";
			}
			Destroy(gameObject);
		}
		else if (other.name == "BlueT")
		{
			if (playerType == "green")
			{
				bluescore.text = "X1.5";
			}
			else
			{
				bluescore.text = "X1.0";
			}
			Destroy(gameObject);
		}
		else if (other.name == "GreenT")
		{
			if (playerType == "red")
			{
				greenscore.text = "X1.5";
			}
			else
			{
				greenscore.text = "X1.0";
			}
			Destroy(gameObject);
		}
	}
}
