using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform grabPosition;
    [SerializeField] private float throwForce = 1000;
    public bool bigEntity;

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
            if (grabbedItem.TryGetComponent(out PlayerInteractor inti) && inti.bigEntity)
                return;
            grabbedItem.parent = grabPosition;
            grabbedItem.localPosition = Vector3.zero;
        }

        //if(interacted && grabPosition.childCount > 0)
        //{
        //    grabbedItem.parent = null;
        //}

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (grabbedItem.TryGetComponent(out PlayerInteractor inti) && inti && !inti.bigEntity)
            {
                PlayerMover mover = grabbedItem.GetComponent<PlayerMover>();
                mover.enabled = true;
                mover.AddImpact(Vector3.up, 10);
            }
        }

        interacted = false;
    }

    void OnFire(InputValue interactVal)
    {
        interacted = interactVal.isPressed;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("item") || other.transform.CompareTag("Player"))
        {
            collided = true;
            grabbedItem = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("item") || other.transform.CompareTag("Player"))
        {
            collided = false;
            grabbedItem = null;
        }
    }
}
