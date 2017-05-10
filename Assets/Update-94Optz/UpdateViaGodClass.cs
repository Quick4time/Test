using UnityEngine;
using System.Collections;

public class UpdateViaGodClass : MonoBehaviour, IUpdateableObject {

    [SerializeField]
    UpdateableComponent _ui;
    [SerializeField]
    DisableEnableScrToDist _dESTD;

	// Use this for initialization
	void Start () {
        GameLogic.Instance.RegisterUpdateableObject(this);
        //Initialize();
	}
	
    void OnDestroy()
    {
        if (GameLogic.IsAlive)
        {
            GameLogic.Instance.DeregisterUpdateableObject(this);
        }
    }
    protected virtual void Initialize()
    {
        //производные классы должны переопределить этот метод для кода инициализации
        //чтобы избежать замены Start () функционировать случайно
    }
    public virtual void OnUpdate(float dt)
    {
        //_dESTD.CustomUpdate();
        _ui.OnUpdCheck(); // добавляем непосредственно метод для обновления.
    }
}
