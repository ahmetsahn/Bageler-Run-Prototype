using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform bagelTransform;
    public Vector3 offset;
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        offset = transform.position - bagelTransform.position;
    }

    void LateUpdate()
    {
       transform.position = bagelTransform.position + offset;
    }

    private void Update()
    {
        if(playerController.isGameOver)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }
}

