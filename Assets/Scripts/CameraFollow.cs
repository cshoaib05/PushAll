using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 offset;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        pos = player.transform.position + offset;
        transform.position = pos;
    }
}
