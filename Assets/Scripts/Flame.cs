using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flame : MonoBehaviour
{
	bool isAttack = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Monster")
		{
			if (!isAttack)
			{
				if (transform.parent.GetComponent<Player>().type == "red" && other.name == "Green")
					other.GetComponent<Monster>().monstarHP -= 1.5f;
				else if (transform.parent.GetComponent<Player>().type == "green" && other.name == "Blue")
					other.GetComponent<Monster>().monstarHP -= 1.5f;
				else if (transform.parent.GetComponent<Player>().type == "blue" && other.name == "Red")
					other.GetComponent<Monster>().monstarHP -= 1.5f;
				else
					other.GetComponent<Monster>().monstarHP -= 1.0f;
			}
			StartCoroutine(attack());
		}

		else if (other.tag == "Row")
		{
			if (transform.parent.GetComponent<Player>().type == "red" && other.name == "GreenT")
				other.transform.GetChild(0).GetComponent<TextMeshPro>().text = "X1.5";
			else if (transform.parent.GetComponent<Player>().type == "green" && other.name == "BlueT")
				other.transform.GetChild(0).GetComponent<TextMeshPro>().text = "X1.5";
			else if (transform.parent.GetComponent<Player>().type == "blue" && other.name == "RedT")
				other.transform.GetChild(0).GetComponent<TextMeshPro>().text = "X1.5";
			else other.transform.GetChild(0).GetComponent<TextMeshPro>().text = "X1.0";
		}
	}

	IEnumerator attack()
	{
		isAttack = true;
		yield return new WaitForSeconds(1f);
		isAttack = false;
	}
}
