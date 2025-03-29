using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{


    [Header("Input")]
    [SerializeField] private InputManager _Input;


    [Header("Movement Camera")]
    [SerializeField] float speedH = 2.0F;
    [SerializeField] float speedV = 2.0F;
    [SerializeField] float speed = 6.0F;

    private float latestyaw;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float auxSpeed = 0;
    private float auxSpeedH;
    private float auxSpeedV;


    [Header("Animator")]
    private Animator gun_anim;
    private bool IsScope;
    void Start()
    {
        yaw = Camera.main.transform.eulerAngles.x;
        pitch = transform.eulerAngles.y;
        auxSpeed = speed;
        auxSpeedH = speedH;
        auxSpeedV = speedV;
        gun_anim = GetComponentInChildren<Animator>();
        _Input.ShootAction += Shoot;
        _Input.ScopeAction += Scope;
        _Input.MovementAction += Movement;

    }

    private void Shoot()
    {

    }

    void Scope()
    {
        IsScope = !IsScope;
        if (IsScope)
        {
            gun_anim.SetBool("Scope", true);

        }
        else
        {
            gun_anim.SetBool("Scope", false);

        }
    }

    void Movement(Vector2 AxisDir)
    {

        pitch += speedH * AxisDir.x;
        yaw -= speedV * AxisDir.y;
        if (yaw < 70 && yaw > -70)
        {
            latestyaw = yaw;
            transform.eulerAngles = new Vector3(yaw, pitch, 0.0f);
        }
        else
        {
            yaw = latestyaw;
            transform.eulerAngles = new Vector3(latestyaw, pitch, 0.0f);
        }
    }
    private void OnDestroy()
    {
        _Input.ShootAction -= Shoot;
        _Input.ScopeAction -= Scope;
        _Input.MovementAction -= Movement;
    }

}
