using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

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

  public virtual void desactivate() 
  {
    Destroy(gameObject);
  }

  public bool IsActivated()
  {
    return isActivated;
  }

  public void drawIcon()
  {
  }
}
