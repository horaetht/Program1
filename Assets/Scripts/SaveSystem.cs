using System;
using System.IO;
using UnityEngine;

public static class SaveSystem {
    static string FilePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static bool HasSave() => File.Exists(FilePath);

    public static void Save(SaveData data) {
        data.savedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        File.WriteAllText(FilePath, JsonUtility.ToJson(data));
    }

    public static SaveData Load() {
        if (!HasSave()) return null;
        return JsonUtility.FromJson<SaveData>(File.ReadAllText(FilePath));
    }

    public static void Delete() {
        if (HasSave()) File.Delete(FilePath);
    }
}
