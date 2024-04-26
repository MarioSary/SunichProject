using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 0.1f;
    private int pointsIndex;

    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }

    
    void Update()
    {
        if (pointsIndex <= points.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            transform.up = points[pointsIndex].transform.position - transform.position;

            if (transform.position == points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            // if (pointsIndex == points.Length)
            // {
            //     pointsIndex = 0;
            // }
        }
    }
}
