using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace MessegeTest
{
    public class Listener2 : MonoBehaviour, IUpdateableObject
    {
        public const float baseFloatValue = 3.0f;
        public float floatValue = 3.0f;
        StringBuilder sb;

        private void Awake()
        {
            Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnFloatChange);// добавляем функцию с floatom для изменения ее спомощью Messengera/
            Messenger.AddListener(GameEvent.TEST_MESSENGER, TestMessenger);
        }
        private void Start()
        {
            sb = new StringBuilder(5);
            sb.Append("Float ");
            sb.Append("is: ");
            sb.Append(floatValue);
            sb.Append("/");
            sb.Append(baseFloatValue);
            GameLogic.Instance.RegisterUpdateableObject(this);
        }
        private void OnDestroy()
        {
            if (GameLogic.IsAlive)
            {
                GameLogic.Instance.DeregisterUpdateableObject(this);
            }
            Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnFloatChange);
            Messenger.RemoveListener(GameEvent.TEST_MESSENGER, TestMessenger);
        }
        private void OnFloatChange(float value)
        {
            floatValue = baseFloatValue * value;
        }
        public virtual void OnUpdate(float dt)
        {
            Debug.Log(sb.ToString());
        }
        private void TestMessenger()
        {
            Debug.Log("Listener2_Done");
        }
        
    }
}

