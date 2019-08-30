using UnityEngine;

public class MoveController : MonoBehaviour {

    public bool canPush;

    public bool Move(Vector3 direction) {
        bool didMove = false;
        Vector3 possiblePosition = gameObject.transform.position + direction;
        Collider2D[] objsAtDestination = Physics2D.OverlapPointAll(new Vector2(possiblePosition.x, possiblePosition.y));

        // Push if possible
        bool didPush = false;
        GameObject pushableObj = Utils.GetObjectWithTag(objsAtDestination, "Pushable");
        if (canPush && pushableObj != null) {
            didPush = PushObject(pushableObj, direction);
        }

        // Move if possible
        GameObject blockingObj = Utils.GetObjectWithTag(objsAtDestination, "Wall");
        bool destContainsBlockingObj = (blockingObj != null) || (pushableObj != null && !didPush);
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
