using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class t : MonoBehaviour
{
	GameObject parent;

	private void Start()
	{
		parent = transform.parent.gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player")
		{
			if(transform.parent.name == "Red")
				parent.GetComponent<Monster>().state = Monster.State.targetCatch;
			else if (transform.parent.name == "Green")
				parent.GetComponent<Monster>().state = Monster.State.runAway;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.name == "Player")
		{
			parent.GetComponent<Monster>().state = Monster.State.idle;
		}
	}
}
