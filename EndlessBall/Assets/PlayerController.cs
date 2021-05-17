using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject leftPath, rightPath;
    private int lanePosition;
    [SerializeField] private float mSpeed;
    [SerializeField] private SwipeManager _swipeManager;

    private Vector3 TargetPosition;
    private void Start()
    {
        transform.position = leftPath.transform.position;
    }
    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * mSpeed);

        if (_swipeManager.SwipeLeft)//add IsGrounded
            lanePosition = 0;
        if (_swipeManager.SwipeRight)//add IsGrounded
            lanePosition = 1;

        switch (lanePosition)
        {
            case 0:
                transform.position = Vector3.Lerp(transform.position, new Vector3(leftPath.transform.position.x, transform.position.y, transform.position.z), 7 * Time.deltaTime);
                break;
            case 1:
                transform.position = Vector3.Lerp(transform.position, new Vector3(rightPath.transform.position.x, transform.position.y, transform.position.z), 7 * Time.deltaTime);
                break;
        }
        if (_swipeManager.SwipeUp)
            GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * mSpeed * 10);
        if (_swipeManager.Tap)
            Debug.Log("Tap!");

    }
}
