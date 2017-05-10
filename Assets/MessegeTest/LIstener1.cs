using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MessegeTest
{
    public class LIstener1 : MonoBehaviour
    {
        private void Awake()
        {
            Messenger.AddListener(GameEvent.TEST_MESSENGER, TestMessenger);
        }
        private void OnDestroy()
        {
            Messenger.RemoveListener(GameEvent.TEST_MESSENGER, TestMessenger);
        }

        private void TestMessenger()
        {
            Debug.Log("Listener1_Done");
        }
    }
}

