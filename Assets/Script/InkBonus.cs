using UnityEngine;
using System.Collections;

public class InkBonus : Bonus {

  private static float duration = 20.0f;
  private float time = 0.0f;

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

    time += Time.deltaTime;
    if (time > duration)
    {
      time = 0.0f;
      particleEmitter.emit = false;
      desactivate(10.0f);
    }

	}

  public override void activate()
  {
    base.activate();
    gameObject.SetActive(true);
  }

  public override BonusType GetBonusType()
  {
    return BonusType.Ink;
  }
}
