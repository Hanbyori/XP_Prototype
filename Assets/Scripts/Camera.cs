using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public GameObject player;

	private void Update()
	{
		transform.position = player.transform.position + new Vector3(0f, 5.5f, -15f);
		transform.position = new Vector3(transform.position.x, transform.position.y, -15f);
	}
}
