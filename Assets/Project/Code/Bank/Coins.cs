using Assets.Project.Code.DataPersistence;
using Assets.Project.Code.DataPersistence.Data;

namespace Assets.Project.Code.Bank
{
    public class Coins : BankDefault, IDataPersistence
    {
        public void LoadData(GameData data)
        {
            _bankValue.Value = data.CoinsAmount;
        }

        public void SaveData(GameData data)
        {
            data.CoinsAmount = Value;
        }
    }
}