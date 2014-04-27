using UnityEngine;
using System.Collections;

public class BombBonus : Bonus {

  private float projectionForce = 30.0f;
  private Vector3 projDir = new Vector3(1f, 0.5f, 0f);

  // Use this for initialization
  override public void Start()
  {
    base.Start();
  }

  // Update is called once per frame
  override public void Update()
  {
    if (!isActivated)
    {
      return;
    }
  }

  public override void activate()
  {
    Debug.Log("Bomb launched");
    base.activate();
    gameObject.SetActive(true);
    rigidbody.AddForce(transform.TransformDirection(projDir) * projectionForce, ForceMode.Impulse);
  }
}
