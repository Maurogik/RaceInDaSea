﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

  public float speed = 1.0f;
  public float rotateSpeed = 1.0f;
  public Terrain terrain;
  public float heightOffset = 5.0f;
  public Vector3 forward;
  public Vector3 left;
  public int playerIndex = 0;
  public bool enabled = true;

  public Camera followCam;
  public Vector3 CameraPos;

  private Bonus currentBonus;

  private float originalMass;

	// Use this for initialization
	void Start () {
    originalMass = rigidbody.mass;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

    if (!enabled)
    {
      return;
    }

    float x = Input.GetAxis("Horizontal" + (playerIndex + 1));
    float z = Input.GetAxis("Vertical" + (playerIndex + 1));
    x = x != 0 ? x : Input.GetAxis("H" + (playerIndex+1));
    z = z != 0 ? z : Input.GetAxis("V" + (playerIndex + 1));

    Rigidbody rigid = transform.rigidbody;

    Vector3 move = forward * z;
    move = transform.TransformDirection(move);
    move *= speed;

    //transform.position = transform.position + move;

    transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);

    rigid.AddForce(move, ForceMode.Force);


    if (Input.GetButton("Drift" + (playerIndex + 1)) || Mathf.Abs(Input.GetAxis("D" + (playerIndex + 1)))> 0.5f)
    {
      rigid.mass = originalMass / GameConfig.GetInstance().driftStrength;
    }
    else
    {
      rigid.mass = originalMass;
    }

    if ((Input.GetButton("Activate"+(playerIndex+1))
      || Input.GetButton("A" + (playerIndex + 1)))
      && currentBonus != null
      && !currentBonus.IsActivated())
    {
      currentBonus.activate();
    }


    float height = terrain.SampleHeight(transform.position);
    Vector3 pos = transform.position;
    pos.y = Mathf.Max(height + heightOffset, pos.y);
    transform.position = pos;

    /*float camHeight = terrain.SampleHeight(followCam.transform.position);
    Vector3 posCam = transform.TransformPoint(CameraPos);
    posCam.y = Mathf.Max(posCam.y, camHeight + heightOffset);
    transform.position = posCam;
    followCam.transform.LookAt(transform.position);*/

	}

  public void TakeBonus(Bonus bonus)
  {
    if (currentBonus != null && !currentBonus.IsActivated())
    {
      Destroy(currentBonus.gameObject);
    }

    currentBonus = bonus;
    currentBonus.transform.parent = transform;
    currentBonus.transform.rotation = transform.rotation;
    currentBonus.transform.localPosition = currentBonus.posOffset;
  }

  public Bonus.BonusType GetBonusType()
  {
    return currentBonus != null ? currentBonus.GetBonusType() : Bonus.BonusType.None;
  }

}
