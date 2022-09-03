using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
	public static Master instance;

	[Header("Camera")]
	public Vector3 cameraPosition = Vector3.zero;
	public Vector3 cameraRotate = Vector3.zero;

	[Header("Player")]
	public GameObject player;
	public float playerSpeed = 1f;

	[Header("UI")]
	public Image fireImage;

	private void Awake()
	{
		instance = this;
	}
}
