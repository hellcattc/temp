using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarEngine : MonoBehaviour
{
    public GameObject[] wheels;
    private HingeJoint[] engines;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject wheel in wheels) {
            engines[engines.GetUpperBound(0)] = wheel.GetComponent<HingeJoint>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            foreach (HingeJoint engine in engines) {
                var cur = engine.useMotor;
                engine.useMotor = !cur;
            }
        }
    }
}
