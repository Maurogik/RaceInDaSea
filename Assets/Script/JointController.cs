using UnityEngine;
using System.Collections;

public class JointController : MonoBehaviour {
  public float maxRotation = 5.0f;
  public float drag = 0.5f;
  public float angularDrag = 0.5f;
  public float mass = 0.001f;
  public float randomness = 0.5f;
  public float spring = 5.0f;
  public float damping = 5.0f;

  public float time = 0.0f;
  public float animDuration = 10.0f;

  public void Update()
  {
    time += Time.deltaTime;
    if(time > animDuration){
      time = 0.0f;
    }
  }
}
