using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D player;

    void Start() {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 newPos = player.transform.position;
        if (Input.GetButtonDown("Up")) {
            newPos = player.transform.position + Vector3.up;
        } else if (Input.GetButtonDown("Down")) {
            newPos = player.transform.position + Vector3.down;
        }
        if (Input.GetButtonDown("Left")) {
            newPos = player.transform.position + Vector3.left;
        } else if (Input.GetButtonDown("Right")) {
            newPos = player.transform.position + Vector3.right;
        }

        player.transform.SetPositionAndRotation(newPos, Quaternion.identity);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate() {
    }
}
