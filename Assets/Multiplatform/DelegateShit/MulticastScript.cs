using UnityEngine;
using System.Collections;

namespace DelegateShit
{
    public class MulticastScript : MonoBehaviour
    {
        delegate void MultiDelegate();
        MultiDelegate myMultiDelegate;
        [SerializeField]
        bool powerUp;
        [SerializeField]
        bool doubleclick;

        void Start()
        {
            if (myMultiDelegate != null)
            {
                myMultiDelegate();
            }
        }

        private void Update()
        {
            PowerUp();
            if (Input.GetKeyDown(KeyCode.K))
            {
                doubleclick = !doubleclick;
                if (doubleclick)
                {
                    powerUp = true;
                }
                else
                {
                    powerUp = false;
                }
            }
        }

        bool PowerUp()
        {
            if (powerUp)
            {
                print("Orb is powering up!");
                return true;
            }
            else if (!powerUp)
            {
                return false;
            }
            return false;
        }

        void TurnRed()
        {
            print("Turn Red");
        }
    }
}

