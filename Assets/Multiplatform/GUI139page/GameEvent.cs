using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {

    public const string ENEMY_HIT = "ENEMY_HIT";
    public const string SPEED_CHANGED = "SPEED_CHANGED";
    public const string ENEMY_HEAL = "ENEMY_HEAL";
    public const string COLOR_CHANGING = "COLOR_CHANGE";
    public const string TEST_MESSENGER = "TEST_MESSENGER";
    public const string HEALTH_UPDATED = "HEALTH_UPDATED"; // обновление ХП в PlayerManager
    public const string LEVEL_COMPLETE = "LEVEL_COMPLETE";
    public const string LELVEL_FAILED = "LEVEL_FAILED";
    public const string GAME_COMPLETE = "GAME_COMPLETE";
}
