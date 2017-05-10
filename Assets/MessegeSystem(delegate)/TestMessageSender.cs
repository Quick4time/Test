using UnityEngine;
using System.Collections;

public class TestMessageSender : MonoBehaviour {

    // tweak these values in the Inspector to change the contents of the message
    [SerializeField][Range(0, 100)] int _intVal;
    [SerializeField][Range(0,100)] float _floatVal;
    [SerializeField][Range(0, 100)] int _damage;
    [SerializeField][Range(0, 100)] int _manaLow;

    void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            // Send a message through the event system of a particular type.
            // From this end, we really don't care where the message is eventually processed.
            // We only care that it has been sent out at the right time.
            MessagingSystem.Instance.QueueMessage(new MyCustomMessage(_intVal, _floatVal));
            MessagingSystem.Instance.QueueMessage(new DestroyMessege(_damage, _manaLow));
        }
	}
}
