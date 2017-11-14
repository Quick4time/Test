using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Обеспечивает совместную работу классов с несовместимыми интерфейсами.
public class AdapterPattern : MonoBehaviour
{
    interface ISender
    {
        void Send(string message);
    }

    class Requester
    {
        public void SendRequest(string message)
        {
            //HttpRequest req = new HttpRequest();
            //req.UserAgent = Http.ChromeUserAgent();
            //req.Cookies = new CookieDictonary();
            //req.Get(" " + message);
        }
    }

    //Используем шаблон адаптер

class Adapter : Requester, ISender
    {
        Requester kissoClass = new Requester();
        public void Send(string message)
        {
            this.SendRequest(message);
            kissoClass.SendRequest(message);
        }
    }

}
