﻿using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;

namespace Skripts.Global.SaveSystem
{
    public class SaveSystem  {
        private Dictionary<SavableObjectType, ISavable> _savableObjects;

        public SaveSystem(){
            _savableObjects = new()
            {
                { SavableObjectType.Wallet, new Wallet() },
                { SavableObjectType.Progress, new Progress() },
                { SavableObjectType.OpenSkills, new OpenSkills() },
            };

            LoadData();
        }



        private void LoadData() {
            foreach (var (key, savableObject) in _savableObjects) {
                if (!PlayerPrefs.HasKey(key.ToString())) continue;
                var json = PlayerPrefs.GetString(key.ToString());
                JsonUtility.FromJsonOverwrite(json, savableObject);
            }
        }

        public ISavable GetData(SavableObjectType objectType) {
            return _savableObjects[objectType];
        }
        
        public void SaveData(SavableObjectType objectType) {
            var objectToSave = _savableObjects[objectType];
            var json = JsonUtility.ToJson(objectToSave);
            PlayerPrefs.SetString(objectType.ToString(), json);
            PlayerPrefs.Save();
        }

        public void SaveAll() {
            foreach (var (key, value) in _savableObjects) {
                var json = JsonUtility.ToJson(value);
                PlayerPrefs.SetString(key.ToString(), json);
            }
            
            PlayerPrefs.Save();
        }
    }
}
