using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
	bool isAttack = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Monster")
		{
			if (!isAttack) other.GetComponent<Monster>().monstarHP -= 1f;
			StartCoroutine(attack());
		}
	}

	IEnumerator attack()
	{
		isAttack = true;
		yield return new WaitForSeconds(1f);
		isAttack = false;
	}
}
