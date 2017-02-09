using UnityEngine;
using System.Collections;

    [System.Serializable]
    public class enemy : MonoBehaviour, IEnumerable
    {
        public static enemy LastCreated = null;
        public static enemy FirstCreated = null;

        public enemy NextEnemy = null;
        public enemy PrevEnemy = null;

        public string EnemyName = string.Empty;

        void Awake()
        {
            if (FirstCreated == null)
                FirstCreated = this;

            if (enemy.LastCreated != null)
            {
                enemy.LastCreated.NextEnemy = this;
                PrevEnemy = enemy.LastCreated;
            }
            enemy.LastCreated = this;
        }
        void OnDestroy()
        {
            if (PrevEnemy != null)
                PrevEnemy.NextEnemy = NextEnemy;

            if (NextEnemy != null)
                NextEnemy.PrevEnemy = PrevEnemy;
        }

        public IEnumerator GetEnumerator()
        {
            return new EnemyEnumerator();
        }
    }

