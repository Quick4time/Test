using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

enum Worker { Peon, Slave }

public class ConfigurablePattern : MonoBehaviour
{
    //delegate void CurrentlyWeapon();
    //CurrentlyWeapon curWeapon;
    Action curWeapon;

    //delegate void DynamicPatternDelegate();
    //DynamicPatternDelegate DelegateToDo;  
    Action DelegateToDo; // Action это делегат сокращение двух верхних строк.
    Worker myWorker;

    private ActionDelegate myAction = new ActionDelegate();
    bool oc;
    private int curState;

    private void Start()
    {
        curWeapon = Bow;
        curState = 0;
        DelegateToDo += DoNothing;
        DoActionDelegate();
        myWorker = Worker.Peon;
    }

    private void Update()
    {
        DelegateToDo();
        curWeapon();
        SwitchWeapon();
        if (Input.GetKeyDown(KeyCode.A))
        { 
            //curState = curState <= 1 ? curState++ : curState = 0;
            if (curState <= 1)
            {
                curState++;
            }
            else
            {
                curState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            oc = !oc;
                              
            if (oc)
            {
                myWorker = Worker.Peon;
                DelegateToDo -= RabotyagaWork;
                DelegateToDo += PeonWork1;
                DelegateToDo += PeonWork2;
            }
            else
            {
                myWorker = Worker.Slave;
                DelegateToDo -= PeonWork1;
                DelegateToDo -= PeonWork2;
                DelegateToDo += RabotyagaWork;

            }

        }
    }

    void DoActionDelegate()
    {
        myAction.DoSomething("Weapon", () => { print("myActionDelegateWork"); });
    }

    void PeonWork1()
    {
        print("Build House");
    }
    void PeonWork2()
    {
        print("Build Garage");
    }
    void RabotyagaWork()
    {
        print("krychy gaiki bleatb");
    }

    void DoNothing()
    {
        print("I do nothing");
    }

    void SwitchWeapon()
    {
        switch (curState)
        {
            case 0:
                curWeapon = Bow;
                break;
            case 1:
                curWeapon = Pistol;
                break;
            case 2:
                curWeapon = Rifle;
                break;
        }
    }
    void Pistol()
    {
        print("We equip Pistol");
    }

    void Rifle()
    {
        print("We equip Rifle");
    }

    void Bow()
    {
        print("We equip Bow");
    }
}

public class ActionDelegate
{
    Dictionary<string, Action> WorkCompleteFor = new Dictionary<string, Action>();
    public void DoSomething (string ManagerName, Action myDelegate)
    {
        WorkCompleteFor.Add(ManagerName, myDelegate);
        myDelegate();
    }
}


