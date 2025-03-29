using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{


    public Action ShootAction;
    public Action ScopeAction;
    public Action<Vector2> MovementAction;
    public ControllerEnum Mode;
    private void Shoot()
    {
        bool IsShoot = Input.GetMouseButtonDown(0);
        if (IsShoot)
        {
            Debug.Log("Nembak");

            if (ShootAction != null) {
                ShootAction();
            
            }
        }

    }

    private void Scope()
    {
        bool IsScope = Input.GetMouseButtonDown(1);
        if (IsScope)
        {
            Debug.Log("Scope");

            if (ShootAction != null) {

                ScopeAction();
            
            
            } 
        }

    }

    private void Movement()
    {
        float pitch = Input.GetAxis("Mouse X");
        float yaw = Input.GetAxis("Mouse Y");
        if (pitch != 0 || yaw != 0) 
        {
            Debug.Log($"{pitch} {yaw}");
            MovementAction?.Invoke(new Vector2(pitch, yaw));
        }

    }
    void Start()
    {
        
    }

    void Update()
    {
        switch (Mode)
        {
            case ControllerEnum.Mekatronika:

                return;
            case ControllerEnum.PC:
                Movement();
                Scope();
                Shoot();
                break;
        }
    }
}
