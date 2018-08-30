using System;

public static class Score {
    static int score = 0;
    public static Action<int> ChangeScore = delegate { };
    public static int CurrentScore { get { return score; } }
    public static void AddScore(int value)
    {
        score += value;
        ChangeScore(score);
    }
    public static void ResetScore()
    {
        score = 0;
    }


}
