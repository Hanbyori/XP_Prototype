using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
	public enum State { idle, targetCatch, runAway };
	public State state = State.idle;

	Coroutine co;
	Rigidbody rigid;
	Transform target;
	Vector3 dir;

	int randomMovement;
	float coolTime;

	public float moveSpeed = 2f;
	public float monstarHP = 3f;
	bool isCoolDown = false;

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
		target = GameObject.Find("Player").transform;
	}

	private void Update()
	{
		if (monstarHP <= 0) Destroy(gameObject);

		if (state == State.idle && gameObject.name == "Red")
		{
			if (isCoolDown == false)
			{
				randomMovement = Random.Range(1, 4 + 1);
				coolTime = Random.Range(1.0f, 3.1f);
				co = StartCoroutine(Cooldown(coolTime));
			}

			if (randomMovement == 1)
			{
				transform.rotation = Quaternion.Euler(0, -90, 0);
				transform.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			}
			else if (randomMovement == 2)
			{
				transform.rotation = Quaternion.Euler(0, 90, 0);
				transform.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			}
			else if (randomMovement == 3)
			{
				transform.rotation = Quaternion.Euler(0, 0, 0);
				transform.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			}
			else if (randomMovement == 4)
			{
				transform.rotation = Quaternion.Euler(0, 180, 0);
				transform.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			}
		}

		else if (state == State.targetCatch)
		{
			dir = target.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation(dir.normalized);
			transform.rotation = rot;
			transform.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}

		else if (state == State.runAway)
		{
			dir = target.transform.position - transform.position;
			Quaternion rot = Quaternion.LookRotation(-dir.normalized);
			transform.rotation = rot;
			transform.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
	}

	IEnumerator Cooldown(float sec)
	{
		isCoolDown = true;
		yield return new WaitForSeconds(sec);
		isCoolDown = false;
	}

	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.collider.CompareTag("Bullet"))
	//	{
	//		Destroy(collision.collider);

	//		if (GameObject.Find("Player").gameObject.GetComponent<Player>().type == "red" && gameObject.name == "Green")
	//		{
	//			monstarHP -= 1.5f;
	//		}
	//		else if (GameObject.Find("Player").gameObject.GetComponent<Player>().type == "green" && gameObject.name == "Blue")
	//		{
	//			monstarHP -= 1.5f;
	//		}
	//		else if (GameObject.Find("Player").gameObject.GetComponent<Player>().type == "blue" && gameObject.name == "Red")
	//		{
	//			monstarHP -= 1.5f;
	//		}
	//		else monstarHP -= 1;
	//	}
	//}
}
