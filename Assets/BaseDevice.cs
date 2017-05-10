using UnityEngine;
using System.Collections;
public class BaseDevice : MonoBehaviour
{
    public float radius = 3.5f;
//11.1. Построение ролевого боевика изменением назначения проектов 275
void OnMouseDown() //¬ Функция, запускаемая щелчком.
    { 
            Transform player = GameObject.FindWithTag("Player").transform;
        if (Vector3.Distance(player.position, transform.position) < radius)
        {
            Vector3 direction = transform.position - player.position;
            if (Vector3.Dot(player.forward, direction) > .5f)
            {
                Operate(); //¬ Вызов метода Operate(), если персонаж находится рядом и повернут лицом к устройству.
            }
        }
    }
    public virtual void Operate() //Ключевое слово virtual указывает на метод, который можно переопределить после наследования.
    { 
        //¬поведение конкретного устройства 
    }
}

public class ColorChangeDevice : BaseDevice // Наследование от BaseDevice, а не от MonoBehaviour.
{
    public override void Operate() // Наследуя от класса BaseDevice, а не от MonoBehaviour, этот сценарий получает функциональность управления мышью. Затем он переопределяет пустой метод Operate(), добавляя туда поведение, меняющее цвет монитора.
    {
        Color32 random = new Color32((byte)Random.Range(0.0f, 1.0f), (byte)Random.Range(0.0f, 1.0f), (byte)Random.Range(0.0f, 1.0f), (byte)Random.Range(1.0f, 1.0f));
        GetComponent<SpriteRenderer>().color = random;
    }
}
/* // Проверяет, принадлежит ли обьект, на котором был сделан щелчок, слою Ground/
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
RaycastHit mouseHit;
if (Physics.Raycast(ray, out mouseHit)) {
GameObject hitObject = mouseHit.transform.gameObject; │
if (hitObject.layer == LayerMask.NameToLayer("Ground")) { │
_targetPos = mouseHit.point;
_curSpeed = moveSpeed;
}
}
*/
