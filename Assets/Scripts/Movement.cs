using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 10;
    public float rotationSpeed = 500;

    public Animator anim;

    private Touch touch;

    private Vector3 lastTouch;
    private Vector3 firstTouch;

    private bool touchStarted;
    private bool Moving;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
    }



    

    public bool IsMoving()
    {
        return Moving;
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }
    Vector3 CalculateDirection()
    {
        Vector3 temp = (lastTouch - firstTouch).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }



    public void MovePlayer()
    {
        if (anim)
        {
            anim.SetBool("isMoving", Moving);
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStarted = true;
                Moving = true;
                lastTouch = touch.position;
                firstTouch = touch.position;
            }
        }
        if (touchStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                lastTouch = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                lastTouch = touch.position;
                Moving = false;
                touchStarted = false;
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }
}
