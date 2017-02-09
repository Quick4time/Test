using UnityEngine;
using System.Collections;

public class MoweTor : MonoBehaviour {
    //------------------------------------------------
    // СНАЧАЛА ПЕРЕДЕЛАТЬ ЧТО БЫ РАБОТАЛО, А ЕСЛИ БУДЕТ РАБОТАТЬ НЕКОРРЕКТНО ЗАТЕМ ЧТО-ТО МЕНЯТЬ(ТО ЕСТЬ FindGameObjectsWithTag(через GameObject) либо Object.FindObjectOfType(через скрипт Object) в определенном ближайшем радиусе вокруг игрока либо камеры исполюзуя текущий код).
    // ПЛАН А: ПЕРЕДЕЛАТЬ КОД ДЛЯ КЛИМБА В ОСНОВНОЙ СЦЕНЕ(РАБОЧАЯ СХЕМА).
    // ПЛАН Б: ЛИБО ЗАДАТЬ КЛИМБУ ТРАНСФОРМАЦИЮ ГЕРОЯ(СКОРЕЕ ВСЕГО ТОЖЕ РАБОЧАЯ, НО КРИВАЯ) ТОЛЬКО БЕЗ СИНГЛТОНА.
    // ВАЖНОЕ ОБНОВЛЕНИЕ ЗАМЕНИТЬ FindGameObjectsWithTag на IEnumerator (увеличим скорость и производительность) !!!!___---СТРАНИЦА В КНИГЕ 212---___!!!!!!
    // ИЛИ СДЕЛАТЬ РАДИУС ПОИСКА С ПОМОЩЬЮ FindGameObjectsWithTag и этот радиус задать Main Camer'ой. !!!!
    // ОПТИМИЗИРОВАТЬ ПО МАКСИМУМ ВОЗМОЖНО ПРИМЕНИТЬ СОБЫТИЙНОЕ ПРОГРАММИРОВАНИЕ(Раздел с камерами).
    //------------------------------------------------
    [HideInInspector]
    public GameObject[] target;
    string tagenemy = "Enemy";
    public float speed = 0.2f;
    bool stoptimer;
    public LayerMask LayEnemy;
    Color gizmocolor = new Color(1f, 0f, 0f, 0.3f);
    /// <summary>
    /// string space = string.Empty; // пустые строки лучше писать так!!!
    /// </summary>

    void Start()
    {
        stoptimer = false;
        target = GameObject.FindGameObjectsWithTag(tagenemy);
    }

    void Update()
    {
        MoweTorw();
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            IEnumerator EN = enemy.FirstCreated.GetEnumerator();
            while (EN.MoveNext())
            {
                Debug.Log(((enemy)EN.Current).EnemyName);
            }
        }*/
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmocolor;
        Gizmos.DrawSphere(this.transform.position, 2.3f); 
    }
    // Возможно оптимизировать IEnumeratorom
    // сделать более публичной функцией (сделать публичными внутренюю переменную Nearst)
    void MoweTorw()
    {
        GameObject Nearst = target[0];
        float shortestDist = Vector2.Distance(transform.position, target[0].transform.position);
        float step = speed * Time.deltaTime;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 2.3f, LayEnemy);

        foreach (GameObject obj in target)
        {
            float Distance = Vector2.Distance(transform.position, obj.transform.position);
            if (Distance < shortestDist)
            {
                Nearst = obj;
                shortestDist = Distance;
            }
        }
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                transform.position = Vector2.MoveTowards(transform.position, Nearst.transform.position, step); // плавное перемещение
                //transform.position = Vector2.MoveTowards(transform.position, Nearst.transform.position, speed); // мгновенное премещение
            }
        }
        /*
        if (!stoptimer)
        {
            //Debug.Log(Time.time);
        }
        if (transform.position == Nearst.transform.position)
        {
            stoptimer = true;
        }
        */
    }
}
