using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : IProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}