using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MessegeTest
{
    public class SenderMessega : MonoBehaviour
    {
        private float floatValueMessenger = 5.0f;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, floatValueMessenger);// после запятой стоит число которое будет заменено в функции со float'ом.
                Messenger.Broadcast(GameEvent.TEST_MESSENGER);
            }
        }
    }
}

