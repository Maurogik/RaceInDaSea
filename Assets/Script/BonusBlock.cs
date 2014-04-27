using UnityEngine;
using System.Collections;

public class BonusBlock : MonoBehaviour {

  public Bonus bonus;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
      other.gameObject.GetComponent<Control>().TakeBonus(bonus);
      Destroy(gameObject);
		}
	}
}
