using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

  private float time = 0f;
  public float timeout = 1f;

  void Update() {
    time += Time.deltaTime;

    if (time >= timeout)
      Destroy(gameObject);
  }
}
