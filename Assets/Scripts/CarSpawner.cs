using System;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public Vector3 direction;
    public double spawnRateInMs;
    public GameObject carPrefab;
    public int carTimeToLiveInSec;

    double lastSpawnEpoch;

    void Start() {
        lastSpawnEpoch = 0;
    }

    void Update() {
        double now = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        if (now - lastSpawnEpoch > spawnRateInMs) {
            SpawnCar();
            lastSpawnEpoch = now;
        }
    }

    void SpawnCar() {
        GameObject newCar = Instantiate(carPrefab) as GameObject;
        SpriteRenderer carSprite = newCar.GetComponent<SpriteRenderer>();
        carSprite.sortingLayerName = "DynamicEnvironment";
        PositionCar(newCar);
        CarController carController = newCar.GetComponent<CarController>();
        carController.StartMoving(direction);
        Destroy(newCar, carTimeToLiveInSec);
    }

    void PositionCar(GameObject newCar) {
        if (direction.Equals(Vector3.up)) {
            newCar.transform.position = transform.position;
            newCar.transform.SetPositionAndRotation(gameObject.transform.position + new Vector3(0.5f, -1.5f, 0), Quaternion.identity);
            newCar.transform.Rotate(0, 0, 270);
            newCar.transform.parent = transform;
        } else if (direction.Equals(Vector3.down)) {
            newCar.transform.position = transform.position;
            newCar.transform.SetPositionAndRotation(gameObject.transform.position + new Vector3(-0.5f, 1.5f, 0), Quaternion.identity);
            newCar.transform.Rotate(0, 0, 90);
            newCar.transform.parent = transform;
        }
    }
}
