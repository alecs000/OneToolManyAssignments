using Assets.Project.Code.DataPersistence.Data;

namespace Assets.Project.Code.DataPersistence
{
    public interface IDataPersistence
    {
        void LoadData(GameData data);
        void SaveData(GameData data);
    }
}