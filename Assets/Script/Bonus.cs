using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

  public enum BonusType
  {
    None,
    Bomb,
    Ink
  }

  protected bool isActivated;
  public Vector3 posOffset;

	// Use this for initialization
	public virtual void Start () {
    isActivated = false;
	}
	
	// Update is called once per frame
	public virtual void Update () {
	  
	}

  public virtual void activate()
  {
    isActivated = true;
  }

  public virtual void desactivate(float delay = 0.1f) 
  {
    Invoke("destroy", delay);
  }

  private void destroy()
  {
    Destroy(gameObject);
  }

  public bool IsActivated()
  {
    return isActivated;
  }

  public virtual BonusType GetBonusType()
  {
    return BonusType.None;
  }
}
