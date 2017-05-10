using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour {
    // Расталкивание коробок персонажем. Стр 195.
    /*
     * ...
public float pushForce = 3.0f; ¬ Величина прилагаемой силы.
...
void OnControllerColliderHit(ControllerColliderHit hit) {
_contact = hit;
Rigidbody body = hit.collider.attachedRigidbody; ¬ Проверка, есть ли у участвующего в столкновении объекта компонент Rigidbody, обеспечивающий реакцию на приложенную силу.
if (body != null && !body.isKinematic) {
body.velocity = hit.moveDirection * pushForce; ¬ Назначение физическому телу скорости.
}
}
...
Особых объяснений этот код не требует: при любом столкновении персонажа с объектом проверяется наличие у этого объекта компонента Rigidbody. 
В случае положительного результата проверки этому компоненту присваивается указанная скорость.
Запустите игру и заставьте персонажа бежать прямо на штабель — штабель вполне реалистично рассыплется. 
Как видите, имитация физического явления не потребовала от вас особых усилий! Благодаря встроенному в Unity механизму имитации физики, нам не приходится писать объемный код. 
Мы легко заставили объекты двигаться в ответ на столкновение, но есть и другой вариант реакции — генерация
    // Триггер. 8.2. Взаимодействие с объектами путем столкновений 197
using UnityEngine;
using System.Collections;
public class DeviceTrigger : MonoBehaviour {
[SerializeField] private GameObject[] targets; ¬ Список целевых объектов, которые будет активировать данный триггер.

void OnTriggerEnter(Collider other) { ¬
foreach (GameObject target in targets) {
target.SendMessage("Activate");
}
}
void OnTriggerExit(Collider other) { ¬
foreach (GameObject target in targets) {
target.SendMessage("Deactivate");
}
}
}

Листинг 8.7. Добавление активирующей и деактивирующей функций в сценарий DoorOpenDevice
...
public void Activate() {
if (!_open) { ¬ Открывает дверь, только если она пока не открыта.
Vector3 pos = transform.position + dPos;
transform.position = pos;
_open = true;
}
}
public void Deactivate() {
if (_open) { ¬ Аналогично, закрывает дверь только при условии, что она уже не закрыта.
Vector3 pos = transform.position - dPos;
transform.position = pos;
_open = false;
}
}
...
     */
}
