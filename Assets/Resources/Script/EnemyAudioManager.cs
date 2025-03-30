using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _DieSfx;
    public void PlayDie()
    {
        _DieSfx.Play();

    }
}
