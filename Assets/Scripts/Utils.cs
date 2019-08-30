using System;
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

    public static double Now() {
        return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
    }

}