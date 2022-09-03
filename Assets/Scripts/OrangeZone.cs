using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeZone : MonoBehaviour
{
	bool isAttack = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!isAttack) StartCoroutine(attack());
		}
	}

	IEnumerator attack()
	{
		isAttack = true;
		GameObject.Find("Player").GetComponentInParent<Player>().hp -= 1;
		yield return new WaitForSeconds(0.2f);
		isAttack = false;
	}
}
