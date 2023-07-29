using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMover BigPlayerMover;
    [SerializeField] private PlayerMover SmallPlayerMover;
    [SerializeField] private PlayerInteractor BiggerPlayerInteractor;
    [SerializeField] private PlayerInteractor SmallPlayerInteractor;

    private void Start()
    {
        BigPlayerMover.enabled = false;
        BiggerPlayerInteractor.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            BigPlayerMover.enabled = !BigPlayerMover.enabled;
            SmallPlayerMover.enabled = !SmallPlayerMover.enabled;
            BiggerPlayerInteractor.enabled = !BiggerPlayerInteractor.enabled;
            SmallPlayerInteractor.enabled = !SmallPlayerInteractor.enabled;
        }

    }


}
