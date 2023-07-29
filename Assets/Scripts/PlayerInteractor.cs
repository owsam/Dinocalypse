using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;

    private bool interacted;
    private bool collided;

    private Transform grabbedItem;

    void Start()
    {

    }

    void Update()
    {
        if (interacted && collided)
        {
            grabbedItem.parent = grabPosition;
            grabbedItem.localPosition = Vector3.zero;
        }

        interacted = false;
    }

    void OnFire(InputValue interactVal)
    {
        interacted = interactVal.isPressed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("item"))
        {
            collided = true;
            grabbedItem = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("item"))
        {
            collided = false;
            grabbedItem = null;
        }
    }
}
