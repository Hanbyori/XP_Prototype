using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	[Header("Player Input")]
	public GameObject player;

	[Header("Camera Position")]
	public float yPos;
	public float zPos;

	[Header("Camera Rotation")]
	public float xRot;

	private void Update()
	{
		transform.rotation = Quaternion.Euler(xRot, transform.rotation.y, transform.rotation.z);
		transform.position = player.transform.position + new Vector3(0f, yPos, 0f);
		transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
	}
}
