using UnityEngine;
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


    float height = terrain.SampleHeight(transform.position);
    Vector3 pos = transform.position;
    pos.y = Mathf.Max(height + heightOffset, pos.y);
    transform.position = pos;

    //rigid.AddTorque(0.0f, x * rotateSpeed, 0.0f, ForceMode.Force);

	}

  void OnGUI(){

    GUI.skin = GameConfig.GetInstance().skin;

    if (playerIndex == 0)
    {
      GUI.Label(new Rect(50, 50, 200, 80), "Player 1" );
    }
    else
    {
      GUI.Label(new Rect(50, Screen.height / 2 + 50, 200, 80), "Player 2" );
    }
  }
}
