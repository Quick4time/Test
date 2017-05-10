using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    // Важно page 158 MultiplatRazrab.
    [SerializeField]
    private Settingpoup settingPoups;
    [SerializeField]
    private InventoryPopup inventoryPopup;
    [SerializeField]
    private TMPro.TextMeshProUGUI healthLabel;
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreLabel;
    //[SerializeField]
    //private Text levelEnding;

    public float Score
    {
        get { return _score; }
        set
        {
            _score = Mathf.Clamp(value, 0.0f, 9.0f);
            PlayerPrefs.SetFloat("score", _score);
        }
    }
    private float _score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated); // ¬ Задаем подписчика для события обновления здоровья.
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.ENEMY_HEAL, OnEnemyHeal);
        //Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.ENEMY_HEAL, OnEnemyHeal);
        //Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
    }

    private void Start()
    {
        OnHealthUpdated();//¬ Вызов функции вручную при загрузке.
        //levelEnding.gameObject.SetActive(false);
        inventoryPopup.gameObject.SetActive(false);// ¬ Всплывающее окно инициализируется как скрытое.
        //_score = 0;
        _score = PlayerPrefs.GetFloat("score", 0.0f);
        scoreLabel.text = _score.ToString();
        settingPoups.Close();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // ¬ Отображение всплывающего окна нажатием клавиши M.
        {
            bool isShowing = inventoryPopup.gameObject.activeSelf;
            inventoryPopup.gameObject.SetActive(!isShowing);
            inventoryPopup.Refresh();
        }
    }
    private void OnHealthUpdated() // ¬ Подписчик события вызывает функцию для обновления метки health.
    {
        string message = "Health: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
        healthLabel.text = message;
        Debug.Log("Health is: " + Managers.Player.health + "/" + Managers.Player.maxHealth);
    }
    /*
    private void OnLevelComplete()
    {

    }
    private IEnumerator CompleteLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Complete!";

        yield return new WaitForSeconds(2);

        Managers.Misson.GoToNext();
    }
    */
    public void OnOpenSettings()
    {
        settingPoups.Open();
        Debug.Log("open settings");
    }

    public void OnPointerDown()
    {
        Debug.Log("On pointer down");
    }

    public void OnEnemyHit()
    {
        _score += 1.0f;
        scoreLabel.text = _score.ToString();
    }
    public void OnEnemyHeal()
    {
        _score -= 1.0f;
        scoreLabel.text = _score.ToString();
    }
}
/*
 ...Пример рассылки сообщения об изменении скорости. 
public const float baseSpeed = 3.0f; ¬ Базовая скорость, меняемая в соответствии с положением ползунка.
...
void Awake() {
Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
}
void OnDestroy() {
Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
}
...
private void OnSpeedChanged(float value) { ¬ Метод, объявленный в подписчике для события SPEED_CHANGED.
speed = baseSpeed * value;
}
...
*/
/* Страница 158 Мульти Messenger.
    6.4.3. Рассылка и слушание сообщений проекционного дисплея
В предыдущем разделе сообщение о событии посылалось сценой и принималось проекционным дисплеем. Сходным образом UI-элементы могут посылать сообщения, которые будут слушаться как игроками, так и врагами. В результате параметры, которые игрок укажет во всплывающем окне, начнут влиять на настройки игры.
Откройте сценарий WanderingAI.cs и добавьте туда код следующего листинга.
Листинг 6.10. Добавление подписчика события в сценарий WanderingAI
...
public const float baseSpeed = 3.0f; ¬ Базовая скорость, меняемая в соответствии с положением ползунка.
...
void Awake() {
Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
}
void OnDestroy() {
Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
}
...
private void OnSpeedChanged(float value) { ¬ Метод, объявленный в подписчике для события SPEED_CHANGED.
speed = baseSpeed * value;
}
...
Методы Awake() и OnDestroy() в данном случае тоже добавляют и удаляют подписчика, но на этот раз нам предстоит иметь дело еще и со значением, задающим скорость перемещения врага.
СОВЕТ В предыдущем разделе мы использовали обобщенное событие, в то время как система рассылки позволяет передавать не только сообщения, но и значения. Для этого к подписчику достаточно добавить определение типа; обратите внимание на дополнение <float> в команде задания подписчика.
Внесем аналогичные изменения в сценарий FPSInput.cs, чтобы повлиять на скорость перемещения игрока. Содержимое следующего листинга отличается от листинга 6.10 только значением переменной baseSpeed у игрока.
6.5. Заключение 159
Листинг 6.11. Добавление подписчика события в сценарий FPSInput
...
public const float baseSpeed = 6.0f; ¬ Это значение отличается от указанного в листинге 6.10.
...
void Awake() {
Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
}
void OnDestroy() {
Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
}
...
private void OnSpeedChanged(float value) {
speed = baseSpeed * value;
}
...
Напоследок нам требуется рассылка значений скорости из сценария SettingsPopup в ответ на изменение положения ползунка. Код этой рассылки приведен в следующем листинге.
Листинг 6.12. Рассылка сообщения сценарием SettingsPopup
public void OnSpeedValue(float speed) {
Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed); ¬
...
Теперь при изменении положения ползунка скорость перемещения врага и игрока будет меняться. Щелкните на кнопке Play и убедитесь сами! 
*/
/*
 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIController : MonoBehaviour {
[SerializeField] private Text healthLabel; ¬ Ссылка на UI-объект в сцене.
[SerializeField] private InventoryPopup popup;
void Awake() { ¬ Задаем подписчика для события обновления здоровья.
Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
}
void OnDestroy() {
Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
}
void Start() {
OnHealthUpdated(); ¬ Вызов функции вручную при загрузке.
popup.gameObject.SetActive(false); ¬ Всплывающее окно инициализируется как скрытое.
11.1. Построение ролевого боевика изменением назначения проектов 279
}
void Update() {
if (Input.GetKeyDown(KeyCode.M)) { ¬ Отображение всплывающего окна нажатием клавиши M.
bool isShowing = popup.gameObject.activeSelf;
popup.gameObject.SetActive(!isShowing);
popup.Refresh();
}
}
private void OnHealthUpdated() { ¬ Подписчик события вызывает функцию для обновления метки health.
string message = "Health: " + Managers.Player.health + "/" +
Managers.Player.maxHealth;
healthLabel.text = message;
}
}

    Листинг 11.13. Проверка UI в сценарии PointClickMovement
using UnityEngine.EventSystems;
...
void Update() {
Vector3 movement = Vector3.zero;
if (Input.GetMouseButton(0) &&
!EventSystem.current.IsPointerOverGameObject()) {
...
Обратите внимание на условную инструкцию, проверяющую местоположение указателя мыши в момент щелчка. 
На этом работу над общей структурой интерфейса можно считать выполненной, поэтому давайте перейдем к всплывающему окну с инвентарем.
*/
