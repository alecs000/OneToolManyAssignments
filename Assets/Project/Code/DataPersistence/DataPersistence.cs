using Assets.Project.Code.DataPersistence.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Project.Code.DataPersistence
{
    public class DataPersistence : MonoBehaviour
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        [SerializeField] private bool useEncryption;

        private GameData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _dataHandler;

        private void Start()
        {
            _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        public void NewGame()
        {
            _gameData = new GameData();
        }

        public void LoadGame()
        {
            _gameData = _dataHandler.Load();
            if (_gameData == null)
            {
                NewGame();
            }

            foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }
        }

        public void SaveGame()
        {
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
            foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(_gameData);
            }

            _dataHandler.Save(_gameData);
        }
        private void OnDestroy()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
                .OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }
    }
}