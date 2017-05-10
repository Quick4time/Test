using UnityEngine;
using System.Collections;

// Note: This code varies slightly from the code in the book. 
// This version disables an assigned object, rather than deactivating the Component.

public class DisableObjectsByDistance : MonoBehaviour
{

    DisableEnableScrToDist DisableScr1;
    GameObject DisGO1;

    DisableEnableScrToDist DisableScr2;
    GameObject DisGO2;

    [SerializeField]
    GameObject _target;
    [SerializeField]
    float _maxDistance;
    [SerializeField]
    int _coroutineFrequency;
    [SerializeField]
    string _objectName;
    
    [SerializeField]
    GameObject _objectToDisable;
    

    void Start()
    {
        
        DisGO1 = GameObject.FindGameObjectWithTag("DisObjByDis");
        DisGO2 = GameObject.FindGameObjectWithTag("DisObjByDis1");

        DisableScr1 = (DisableEnableScrToDist)DisGO1.GetComponent(typeof(DisableEnableScrToDist));
        DisableScr2 = (DisableEnableScrToDist)DisGO2.GetComponent(typeof(DisableEnableScrToDist));
        /*
        DisableScr1 = GetComponent<DisableEnableScrToDist>();
        DisableScr2 = GetComponent<DisableEnableScrToDist>();
        */
        StartCoroutine(DisableAtADistance());
        
    }

    IEnumerator DisableAtADistance()
    {
        while (true)
        {
            float distSqrd = (transform.position - _target.transform.position).sqrMagnitude;


            if (distSqrd < _maxDistance * _maxDistance)
            {
                if (!_objectToDisable.activeSelf)
                {
                    Debug.Log(string.Format("{0} enabled", _objectName));
                    _objectToDisable.SetActive(true);
                    DisableScr1.enabled = true;
                    DisableScr2.enabled = false;
                }
            }
            else if (distSqrd > _maxDistance * _maxDistance)
            {
                if (_objectToDisable.activeSelf)
                {
                    Debug.Log(string.Format("{0} disabled", _objectName));
                    _objectToDisable.SetActive(false);
                    DisableScr1.enabled = false;
                    DisableScr2.enabled = true;
                }
            }

            for (int i = 0; i < _coroutineFrequency; ++i)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
