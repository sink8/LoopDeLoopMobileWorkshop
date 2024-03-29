using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement2 : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotateSpeed = 5.0f;

    Vector3 newPosition;

    void Start() {
        PositionChange();
    }

    void PositionChange() {
        newPosition = new Vector3(Random.Range(-2.1f, 2.1f), Random.Range(-4.0f, 5.6f),0);

;
    }

    void Update() {
        if (Vector3.Distance(transform.position, newPosition) < 1f)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

    }

}
