using UnityEngine;

public class Utils {

    public static GameObject GetObjectWithTag(Collider2D[] colliders, string tag) {
        foreach (Collider2D collider in colliders) {
            if (collider.CompareTag(tag)) {
                return collider.gameObject;
            }
        }
        return null;
    }

}