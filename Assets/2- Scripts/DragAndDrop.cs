using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
    
    //BACK TO POS IN WRONG SITUATIONS
    private bool isLocked;
    [SerializeField] private GameObject[] product;
    [SerializeField] private GameObject[] productRightPos;
    [SerializeField] private Vector3[] productInFirstPos;
    [SerializeField] private float dropDist;

    private void Start()
    {
        for (int i = 0; i < product.Length; i++)
        {
            productInFirstPos[i] = product[i].transform.position;
        }
        
    }

    public void Update()
    {
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            dragging = false;

            for (int i = 0; i < product.Length; i++)
            {
                product[i].transform.position = productInFirstPos[i];
            }
            
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Product" )
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;
                }
            }
        }

        if (dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            for (int i = 0; i < Mathf.Min(product.Length, productRightPos.Length); ++i)
            {
                float Distance = Vector3.Distance(product[i].transform.position, productRightPos[i].transform.position);
                
                if (Distance < dist)
                {
                    isLocked = true;
                    product[i].transform.position = productRightPos[i].transform.position;
                }
                else
                {
                    product[i].transform.position = productInFirstPos[i];
                }
                
                dragging = false;
            }
            
        }
    }
    

    /*public void DropObjects()
    {
        
            float Distance = Vector3.Distance(product.transform.position, productRightPos.transform.position);

            if (Distance < dist)
            {
                isLocked = true;
                product.transform.position = productRightPos.transform.position;
            }
            else
            {
                product.transform.position = productInFirstPos;
            } 
        
        
    }*/
}
