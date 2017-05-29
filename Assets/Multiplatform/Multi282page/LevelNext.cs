using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNext : MonoBehaviour {
    // А также рестарт уровня.
    [SerializeField]
    private TMPro.TextMeshProUGUI levelEnding;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.LELVEL_FAILED, OnLevlelFaild);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);

    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.LELVEL_FAILED, OnLevlelFaild);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    private void Start()
    {
        levelEnding.gameObject.SetActive(false);
    }
    
    void OnLevelComplete()
    {
        StartCoroutine(LevelComplete());
    }

    private IEnumerator LevelComplete()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Complete!";

        yield return new WaitForSeconds(2);

        Managers.Misson.GoToNext();

    }
    private void OnGameComplete()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "You Finished the Game!";
    }

    private void OnLevlelFaild()
    {
        StartCoroutine(FailLevel());
    }
    private IEnumerator FailLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Faild";

        yield return new WaitForSeconds(2);

        Managers.Player.Respawn();
        Managers.Misson.RestartCurrent();
    }
    public void SaveGame()
    {
        Managers.Data.SaveGameState(); // Сохранение игры
    }
    public void LoadGame()
    {
        Managers.Data.LoadGameState(); // Загрузка игры
    }

}
