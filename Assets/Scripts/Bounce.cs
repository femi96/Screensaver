using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

  private BounceBox box;
  private Vector3 v;

  public float width;
  public float height;
  public float speed = 1f;

  public bool ifDiag = false;
  public bool ifRandomStart = false;

  void Start() {
    box = Object.FindObjectOfType<BounceBox>();

    if (ifRandomStart)
      transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(-2f, 2f), 0);

    v = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

    if (ifDiag)
      v = new Vector3(v.x * Mathf.Abs(v.y), v.y * Mathf.Abs(v.x), v.z);

    v = v.normalized;
  }

  private float wTimer = 10f;
  private float hTimer = 10f;
  private float sparkleTimer = 0f;
  public GameObject sparkle;

  void Update() {
    transform.position += v * Time.deltaTime * speed;
    wTimer += Time.deltaTime;
    hTimer += Time.deltaTime;

    if (transform.position.x - width / 2f <= -box.width / 2f) {
      v = new Vector3(Mathf.Abs(v.x), v.y, 0);
      wTimer = 0f;
    }

    if (transform.position.x + width / 2f >= box.width / 2f) {
      v = new Vector3(-Mathf.Abs(v.x), v.y, 0);
      wTimer = 0f;
    }

    if (transform.position.y - height / 2f <= -box.height / 2f) {
      v = new Vector3(v.x, Mathf.Abs(v.y), 0);
      hTimer = 0f;
    }

    if (transform.position.y + height / 2f >= box.height / 2f) {
      v = new Vector3(v.x, -Mathf.Abs(v.y), 0);
      hTimer = 0f;
    }

    sparkleTimer -= Time.deltaTime;
    sparkleTimer = Mathf.Max(sparkleTimer, 0f);

    if (wTimer < 0.1f && hTimer < 0.1f && sparkleTimer <= 0f) {
      sparkleTimer = 5f;
      Instantiate(sparkle, transform.position, Quaternion.identity, transform);
    }
  }
}
