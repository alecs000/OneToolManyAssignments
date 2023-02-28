using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Bank
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