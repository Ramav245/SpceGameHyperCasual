public interface IScoreSystem
{
    float Score { get; }
    ScoreChangedEvent OnScoreChanged { get; }
    void ModifyScore(float amount);

    void ResetScore();
}