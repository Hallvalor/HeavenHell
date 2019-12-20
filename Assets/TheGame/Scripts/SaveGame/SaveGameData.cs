using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGameData
{//saves game

        public static SaveGameData currentSave = loadOrNewSave();
        public Inventory inventory = new Inventory();
        public Health health = new Health();
        public string savepoint = ""; //last savepoint
        public List<string> deletedObjects = new List<string>(); //list of ID of the deleted items for savegame


        public void save()
        {

            try
            {

                string data = JsonUtility.ToJson(this);
                string filepath = Path.Combine(Application.persistentDataPath, "savegame.save");
                File.WriteAllText(filepath, data);
                DialogUI dr = Object.FindObjectOfType<DialogUI>();
                 if (dr != null)
                  dr.showSavedInfo();
        }
        catch (System.Exception ex)
            {
                Debug.LogError("Can't save file.");
            }


        }

        private static SaveGameData loadOrNewSave()
        {
            SaveGameData result = new SaveGameData();
            string filepath = Path.Combine(Application.persistentDataPath, "savegame.save");

            if (File.Exists(filepath))
            {
                try
                {
                    string data = File.ReadAllText(filepath);
                    result = JsonUtility.FromJson<SaveGameData>(data);
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Can't load file " + filepath + "\n" + ex.Message);
                }
            }
            return result;
        }

        public void recordDestroy(GameObject go) //delete object and save it for savegame
        {
            if (!go.name.EndsWith("(Clone)"))  //no spawned objects
            {
                string ID = go.scene.name + "/" + go.name;
                deletedObjects.Add(ID);
            }
            Object.Destroy(go);
        }

        public void recoverDestroy(GameObject go) //if go saved -> delete it
        {
            string ID = go.scene.name + "/" + go.name;
            if (deletedObjects.Contains(ID)) Object.Destroy(go);
        }

    }
