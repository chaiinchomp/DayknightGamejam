using UnityEngine;

public class PlayerController : MonoBehaviour {

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        Vector3 newPos = gameObject.transform.position;
        if (Input.GetButtonDown("Up")) {
            newPos = MoveIfPossible(gameObject.transform.position, Vector3.up);
        } else if (Input.GetButtonDown("Down")) {
            newPos = MoveIfPossible(gameObject.transform.position, Vector3.down);
        }
        if (Input.GetButtonDown("Left")) {
            newPos = MoveIfPossible(gameObject.transform.position, Vector3.left);
        } else if (Input.GetButtonDown("Right")) {
            newPos = MoveIfPossible(gameObject.transform.position, Vector3.right);
        }

        gameObject.transform.SetPositionAndRotation(newPos, Quaternion.identity);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate() {
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Key")) {
            other.transform.SetParent(gameObject.transform);
            other.transform.localPosition = new Vector3(0.25f,0.25f,0);
            other.transform.localScale = new Vector3(0.5f,0.5f,1);
        }
    }

    Vector3 MoveIfPossible(Vector3 currentPosition, Vector3 direction) {
        Vector3 possiblePosition = currentPosition + direction;

        Collider2D objAtDestination = Physics2D.OverlapPoint(new Vector2(possiblePosition.x, possiblePosition.y));
        if (objAtDestination != null && objAtDestination.CompareTag("Wall")) {
            return currentPosition;
        }
        return possiblePosition;
    }

}
