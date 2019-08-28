using UnityEngine;

public class MoveController : MonoBehaviour {

    public bool canPush;

    public bool Move(Vector3 direction) {
        bool didMove = false;
        Vector3 possiblePosition = gameObject.transform.position + direction;
        Collider2D objAtDestination = Physics2D.OverlapPoint(new Vector2(possiblePosition.x, possiblePosition.y));

        // Push if possible
        bool didPush = false;
        bool destContainsPushableObj = objAtDestination != null && objAtDestination.CompareTag("Pushable");
        if (canPush && destContainsPushableObj) {
            didPush = PushObject(objAtDestination.gameObject, direction);
        }

        // Move if possible
        bool destContainsBlockingObj =
                (objAtDestination != null && objAtDestination.CompareTag("Wall"))
                || (destContainsPushableObj && !didPush);
        if (!destContainsBlockingObj) {
            gameObject.transform.SetPositionAndRotation(possiblePosition, Quaternion.identity);
            didMove = true;
        }

        return didMove;
    }

    bool PushObject(GameObject pushableObject, Vector3 direction) {
        MoveController controller = pushableObject.GetComponent<MoveController>();
        return controller.Move(direction);
    }

}
