using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerAdder : MonoBehaviour {

  public GameObject[] bouncers;

  void Start() {

  }

  void Update() {
    if (Input.GetKeyDown("x")) {
      Instantiate(bouncers[Random.Range(0, bouncers.Length)], Vector3.zero, Quaternion.identity, transform);
    }

    if (Input.GetKeyDown("r")) {
      foreach (Transform b in transform)
        Destroy(b.gameObject);
    }
  }
}
