using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IUpdateableObject
{
    void OnUpdate(float dt);
}


public class GameLogic : SingletonAsComponent<GameLogic> {
    public static GameLogic Instance
    {
        get { return ((GameLogic)_Instance); }
        set { _Instance = value; }
    }

    private float _updateFrequency = 1f; //Частота обновления. раз в секунду. 
    private float _timer;

    List<IUpdateableObject> _updateableObjects = new List<IUpdateableObject>();
    public void RegisterUpdateableObject(IUpdateableObject obj)
    {
        if (!_updateableObjects.Contains(obj))
        {
            _updateableObjects.Add(obj);
        }
    }
    public void DeregisterUpdateableObject(IUpdateableObject obj)
    {
        if (_updateableObjects.Contains(obj))
        {
            _updateableObjects.Remove(obj);
        }
    }
    void Update()
    {
        float dt =  Time.deltaTime;

        _timer += dt;
        if(_timer > _updateFrequency)
        {
            _timer -= _updateFrequency;
            for(int i = 0; i < _updateableObjects.Count; i++)
            {
                _updateableObjects[i].OnUpdate(dt);
            }
        }
    }
}
