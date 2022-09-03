using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenZone : MonoBehaviour
{
	bool isAttack = false;

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Monster")
		{
			if (!isAttack) StartCoroutine(attack()); 
		}
	}

	IEnumerator attack()
	{
		isAttack = true;
		transform.GetComponentInParent<Player>().hp -= 1;
		yield return new WaitForSeconds(0.2f);
		isAttack = false;
	}

}
