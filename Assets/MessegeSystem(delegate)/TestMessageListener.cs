using UnityEngine;
using System.Collections;
// Оптимизация Страница 80.
// define a custom message

public class DestroyMessege : BaseMessage
{
    public readonly int _damage;
    public readonly int _manaLow;

    public DestroyMessege(int Health, int Mana)
    {
        _damage = Health;
        _manaLow = Mana;
    }
}
public class MyCustomMessage : BaseMessage
{
    public readonly int _intValue;
    public readonly float _floatValue;

    public MyCustomMessage(int intVal, float floatVal)
    {
        _intValue = intVal;
        _floatValue = floatVal;
    }
}

// Оптимизация Страница 80.
public class TestMessageListener : MonoBehaviour {

    // request to receive messages whenenever 'MyCustomMessage' objects are broadcast
    void Start ()
    {
        // pass a reference to the 'HandleMyCustomMessage' method as the function to call when the message is broadcast from anywhere
        MessagingSystem.Instance.AttachListener(typeof(MyCustomMessage), this.HandleMyCustomMessage); 
	}

    // process the message locally. The method name can be customized to match the message type
    // make it easier to figure out where messages are processed
    bool HandleMyCustomMessage (BaseMessage msg)
    {
        MyCustomMessage castMsg = msg as MyCustomMessage;
        Debug.Log(string.Format("Got the message! {0}, {1}", castMsg._intValue, castMsg._floatValue));
        return true;
    }
    
    // clean-up; make sure we're detached from the event system, so that future
    // 'MyCustomMessage' messages will no longer be sent to this object
    void OnDestroy()
    {
        // NOTE: this can throw null-reference exceptions when Play Mode ends since 
        // the MessagingSystem might have been destroyed first and no longer exists
        if (MessagingSystem.IsAlive)
        {
            MessagingSystem.Instance.DetachListener(typeof(MyCustomMessage), this.HandleMyCustomMessage);
        }
    }
}
