using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleCoords
{
    public double distanceTraversed;
    public double lastLoggedValue;
    public double coordX;
    public double coordY;
    public double angle;
    public double r;
    public double v;

    public void calcNewCoords()
    {
        if (r == 0 && v == 0)
        {
            coordX = 0;
            coordY = 0;
        }
        else
        {
            double newDegrees = ((360 * v * Time.deltaTime) / (2 * Math.PI * r) + angle) % 360;
            angle = newDegrees;
            double radians = (Math.PI / 180) * angle;
            coordX = Math.Cos(radians) * r;
            coordY = Math.Sin(radians) * r;

            //Debug.Log("Coords: (" + coordX + ", " + coordY);

            distanceTraversed += v * Time.deltaTime;
            if (distanceTraversed - lastLoggedValue >= 1)
            {
                lastLoggedValue = distanceTraversed;
                Debug.Log("Distance traversed: " + distanceTraversed + "; on time: " + Time.time);
            }
        }
    }
}

public class TestScript : MonoBehaviour
{
    public CircleCoords firstCircle;
    public CircleCoords secondCircle;
    public CircleCoords thirdCircle;

    // Start is called before the first frame update
    void Start()
    {
        firstCircle = new CircleCoords();
        firstCircle.r = 6;
        firstCircle.v = 4;
        firstCircle.calcNewCoords();

        secondCircle = new CircleCoords();
        secondCircle.r = 8;
        secondCircle.v = 9.46543213587468;
        secondCircle.calcNewCoords();

        thirdCircle = new CircleCoords();
        thirdCircle.r = 0;
        thirdCircle.v = 0;
        thirdCircle.calcNewCoords();

        float newX = (float)firstCircle.coordX + (float)secondCircle.coordX + (float)thirdCircle.coordX;
        float newY = (float)firstCircle.coordY + (float)secondCircle.coordY + (float)thirdCircle.coordY;
        transform.position = new Vector3(newX, newY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        firstCircle.calcNewCoords();
        secondCircle.calcNewCoords();
        thirdCircle.calcNewCoords();

        float newX = (float)firstCircle.coordX + (float)secondCircle.coordX + (float)thirdCircle.coordX;
        float newY = (float)firstCircle.coordY + (float)secondCircle.coordY + (float)thirdCircle.coordY;

        transform.position = new Vector3(newX, newY, 0);
    }
}

