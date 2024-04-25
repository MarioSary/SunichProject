using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag;
    
    [SerializeField] private Vector3 productInFirstPos;
    private bool dragging = false;

    private void Start()
    {
        productInFirstPos = transform.position;
    }

    public void Update()
    {
        if (Input.touchCount != 1)
        { 
            dragging = false;
            return;
        }

        if (Input.touches[0].phase == TouchPhase.Began)
        {
            OnMouseDown();
            //CheckHitProduct();
        }

        if (dragging && Input.touches[0].phase == TouchPhase.Moved)
        {
            OnMouseDrag();
            //DragProduct();
        }

        if (dragging && (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled))
        {
            OnMouseUp();
            //DropProduct();
        }
            
    }
    void OnMouseDown()
    {
        offset = transform.position - TouchWorldPosition();
        //transform.GetComponent<Collider>().enabled = false;
    }
 
    void OnMouseDrag()
    {
        transform.position = TouchWorldPosition() + offset;
    }
 
    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = TouchWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            Debug.Log("Hit");
            
            if(hitInfo.transform.tag == destinationTag)
            {
                Debug.Log("HitSnap");
                transform.position = hitInfo.transform.position;
                
                //to lock on the correct pos
                transform.GetComponent<Collider>().enabled = false;
                //Destroy(hitInfo.transform.gameObject);
            }
            else
            {
                transform.position = productInFirstPos;
                dragging = false;
            }
        }
        //transform.GetComponent<Collider>().enabled = true;
    }
 
    Vector3 TouchWorldPosition()
    {
        var touchScreenPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,
            Camera.main.WorldToScreenPoint(transform.position).z);
        touchScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(touchScreenPos);
    }


    /*//Drag
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
    Vector3 v3;
    
    //Drop
    [SerializeField] private Vector3 productInFirstPos;

    //Snap
    public GameObject[] snapPoints;
    private float snapSensitivity = 2.0f;
    private bool snap = false;
    [SerializeField] private GameObject productHolder;
    [SerializeField] private string snapTag = "ProductHolder";
    
    

    private void Start()
    {
        productInFirstPos = transform.position;
    }

    public void Update()
    {
        if (Input.touchCount != 1)
        { 
            dragging = false; 
            transform.position = productInFirstPos;
            return;
        }

        if (Input.touches[0].phase == TouchPhase.Began)
        {
            CheckHitProduct();
        }

        if (dragging && Input.touches[0].phase == TouchPhase.Moved)
        {
            DragProduct();
        }

        if (dragging && (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled))
        {
            DropProduct();
        }
            
    }

    void CheckHitProduct()
    {
        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;
        
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
    
    void DragProduct()
    {
        v3 = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, dist);
        v3 = Camera.main.ScreenToWorldPoint(v3);
        toDrag.position = v3 + offset;
    }
    
    void DropProduct()
    {
        transform.position = productInFirstPos;
        dragging = false;
    }*/
    

}
