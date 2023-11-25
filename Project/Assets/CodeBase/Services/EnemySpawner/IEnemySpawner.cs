namespace CodeBase.Services.EnemySpawner
{
    public interface IEnemySpawner
    {
        void StartEnemySpawn();
        void OnEnemyDestroyed();
    }
}