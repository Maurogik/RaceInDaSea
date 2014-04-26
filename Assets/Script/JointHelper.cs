using UnityEngine;
using System.Collections;

public class JointHelper : MonoBehaviour {

  public float massModifier = 1.0f;
  


	// Use this for initialization
	void Start () {
    JointController jc = GameController.FindObjectOfType<JointController>();
    CharacterJoint cj = GetComponent<CharacterJoint>();

    float rotation = jc.maxRotation ;//+ (jc.maxRotation * Random.Range(-50, 50)/100.0f * jc.randomness);
    float mass = jc.mass;// +(jc.mass * Random.Range(-50, 50) / 100.0f * jc.randomness);
    float drag = jc.drag;// +(jc.drag * Random.Range(-50, 50) / 100.0f * jc.randomness);
    float angularDrag = jc.angularDrag;// +(jc.angularDrag * Random.Range(-50, 50) / 100.0f * jc.randomness);
    float massModif = Mathf.Sqrt(massModifier);

    SoftJointLimit limit = cj.highTwistLimit;
    limit.limit = rotation;
    limit.spring = jc.spring;
    limit.damper = jc.damping;
    cj.highTwistLimit = limit;

    limit = cj.lowTwistLimit;
    limit.limit = -rotation;
    limit.spring = jc.spring;
    limit.damper = jc.damping;
    cj.lowTwistLimit = limit;

    limit = cj.swing1Limit;
    limit.limit = rotation;
    limit.spring = jc.spring;
    limit.damper = jc.damping;
    cj.swing1Limit = limit;

    limit = cj.swing2Limit;
    limit.limit = rotation;
    limit.spring = jc.spring;
    limit.damper = jc.damping;
    cj.swing2Limit = limit;

    Rigidbody rigid = GetComponent<Rigidbody>();
    rigid.mass = mass * massModif;
    rigid.drag = drag; 
    rigid.angularDrag = angularDrag;



	}
  /*
  void Update()
  {
    float massModif = Mathf.Sqrt(massModifier);

    //Start();

    JointController jc = GameController.FindObjectOfType<JointController>();
    CharacterJoint cj = GetComponent<CharacterJoint>();
    Rigidbody rigid = GetComponent<Rigidbody>();

    Vector3 forceUp = new Vector3(-0.05f, 1f, 0);
    forceUp *= jc.randomness * rigid.mass * Time.deltaTime;

    Vector3 forceDown = new Vector3(-0.05f, -1f, 0);
    forceDown *= jc.randomness * rigid.mass * Time.deltaTime;

    float time = jc.time + massModif;
    time = Mathf.Abs(jc.animDuration - time);

    Vector3 force = forceUp * time + forceDown * jc.time;
    force *= massModif;
    force = transform.TransformDirection(force);



    rigid.AddForce(force, ForceMode.Force);
  }
	*/
}
