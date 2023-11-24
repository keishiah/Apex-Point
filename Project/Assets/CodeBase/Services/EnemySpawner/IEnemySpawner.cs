namespace CodeBase.Services
{
    public interface IEnemySpawner
    {
        void StartEnemySpawn();
        void OnEnemyDestroyed();
    }
}