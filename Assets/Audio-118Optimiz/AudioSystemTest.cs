using UnityEngine;
using System.Collections;
/*
public class AudioSystemTest : MonoBehaviour {
    
	void Update () {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            AudioSystem.Instance.PlaySound("TestSound");
        }
	}
}
*/
public class AudioSystemTest : MonoBehaviour
{

    [SerializeField]
    AudioSource _source; // В соурсе Указываем Independent Audio Source/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioSystem.Instance.PlaySound("TestSound");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //StartCoroutine(STCour(2.0f));
            //_source.PlayDelayed(5.0f);
            _source.PlayOneShot(_source.clip); // выделить PlayOnShot для просмотра существующих определений AudioSource/
        }
    }
    /*
    IEnumerator STCour(float time)
    {
        yield return new WaitForSeconds(time);
        _source.PlayOneShot(_source.clip);
    }
    */
}

