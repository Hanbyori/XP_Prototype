using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
	MeshRenderer render;

	string playerType;

	[Header("Bullet Setting")]
	public float bulletSpeed = 3f;

	private void Start()
	{
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
		if(other.tag == "Monster")
		{
			Debug.Log("∏ÛΩ∫≈Õ ∏¬√„");
		}
	}
}
