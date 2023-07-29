using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMover BigPlayerMover;
    [SerializeField] private PlayerInteractor BiggerPlayerInteractor;
    [SerializeField] private GameObject CameraBig;
    [SerializeField] private GameObject CameraSmall;

    [SerializeField] private PlayerMover SmallPlayerMover;
    [SerializeField] private PlayerInteractor SmallPlayerInteractor;

    private void Start()
    {
        SmallPlayerMover.enabled = false;
        SmallPlayerInteractor.enabled = false;
        CameraSmall.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            BigPlayerMover.enabled = !BigPlayerMover.enabled;
            BiggerPlayerInteractor.enabled = !BiggerPlayerInteractor.enabled;
            SmallPlayerMover.enabled = !SmallPlayerMover.enabled;
            SmallPlayerInteractor.enabled = !SmallPlayerInteractor.enabled;
            CameraBig.SetActive(!CameraBig.activeSelf);
            CameraSmall.SetActive(!CameraSmall.activeSelf);
        }

    }


}
