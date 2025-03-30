using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _ShootSfx;

    public void PlayShoot()
    {
        _ShootSfx.Play();

    }
}
