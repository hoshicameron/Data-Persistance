using System;
using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }
        [field:SerializeField] public string PlayerName { get; set; }
        [field: SerializeField] public int BestScore { get; set; } = 0;
        

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            
            DontDestroyOnLoad(gameObject);
            
            LoadData();
        }

        public void SaveData()
        {
            var gameData = new GameData();
            gameData.Name = PlayerName;
            gameData.BestScore = BestScore;
            var json = JsonUtility.ToJson(gameData);
            
            File.WriteAllText(Application.persistentDataPath+"/SaveData.json",json);
        }

        public void LoadData()
        {
            var path = Application.persistentDataPath + "/SaveData.json";
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var gameData = JsonUtility.FromJson<GameData>(json);
                PlayerName = gameData.Name;
                BestScore = gameData.BestScore;
            }
        }

        [Serializable]
        public class GameData
        {
            public string Name;
            public int BestScore;
        }
    }
}