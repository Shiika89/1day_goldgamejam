using System;

public class GameLoop
{
    public static event Action OnGameStart;
    public static event Action OnGameEnd;

    public static void GameStart() => OnGameStart?.Invoke();
    public static void GameEnd() => OnGameEnd?.Invoke();
}
