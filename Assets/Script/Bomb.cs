using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

  private float explosionForce = 200000.0f;
  private float explosionRadius = 30.0f;
  
  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Bomb exploded");
    GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
    foreach (GameObject player in gc.players)
    {
      player.rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
      rigidbody.isKinematic = true;
      particleSystem.Play();
      Invoke("destroy", 0.2f);
    }
  }

  void destroy()
  {
    Destroy(gameObject);
  }
}
