using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    public Transform anchor;
    private Vector3 startPoint;
    public float speed; 
    private target state;
    public bool isRandom;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
        startPoint = transform.position;
        state = gameObject.GetComponent<target>();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, anchor.position, step);

        if (Vector3.Distance(transform.position, anchor.position) < 0.001f) {
            if (!isRandom) {
                takeCoarsePath();
            } else {
                takeRandomPath();
            }
        }

        void takeRandomPath() {
            var xShift = Random.Range(-5, 5);
            var zShift = Random.Range(-5, 5);
            var vectorShift = new Vector3(xShift, 0, zShift);
            var prevAnchorPos = anchor.position;
            anchor.position += vectorShift; 
        }

        void takeCoarsePath() {
            var prevAnchorPos = anchor.position;
            anchor.position = startPoint;
            startPoint = prevAnchorPos;
        }
    }
}
