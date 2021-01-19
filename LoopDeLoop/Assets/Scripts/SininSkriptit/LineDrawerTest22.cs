using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerTest22 : MonoBehaviour
{
    LineRenderer lr;
    public List<Vector3> linePositions = new List<Vector3>();
    Vector3 mousePos;
    public GameObject drawPrefab;
    public float minDistance = 0.2f;

    public bool circleDrawn = false;
    void Start() {
        var drawing = Instantiate(drawPrefab);
        lr = drawing.GetComponent<LineRenderer>();
    }

    void Update() {
        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.4f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (Input.GetMouseButtonDown(0)) {
            circleDrawn = false;
            lr.loop = false;
            linePositions.Clear();
            lr.SetPositions(new Vector3[] { });
            AddPoint();
        }

        if (Input.GetMouseButton(0)) {
            if (Vector3.Distance(mousePos, linePositions[linePositions.Count - 1]) > minDistance) {
                AddPoint();
            }
        } else if (Input.GetMouseButtonUp(0)) {
            lr.loop = true; 
             circleDrawn = true;
            //linePositions.Clear();
        
        }

        void AddPoint() {
            linePositions.Add(mousePos);
            lr.positionCount = linePositions.Count; //pisteiden koko m��r�
            Vector3 lastPoint = linePositions[linePositions.Count - 1]; // Viimeinen listan piste
            lr.SetPosition(lr.positionCount - 1, lastPoint);
        }

    }
}