using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float offSet;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.position.z - offSet);
    }
}
