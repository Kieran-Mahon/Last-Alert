using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//static class to controll saving player state
public static class SaveSystem {
    
    /*
        To save the players state:
         1. First get reference to the players transform, and the timer.
         2. call SaveSystem.save(transform, timer);
    */
    public static void save(Transform player, float timer) {

        //settup saving
        string path = Application.persistentDataPath + "/data.abc";
        BinaryFormatter formatter = new BinaryFormatter();

        //settup writing stream
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player, timer);

        //save data
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //only update the save settings by calling: SaveSystem.saveSettings();
    public static void saveSettings() {

        //get path
        string path = Application.persistentDataPath + "/data.abc";
        BinaryFormatter formatter = new BinaryFormatter();

        //save to stream
        PlayerData data = load();
        FileStream stream = new FileStream(path, FileMode.Create);
        
        data.volume = AudioManager.volumeSetting; 
        data.sensitivity = PlayerController.mouseXSensitivity;

        data.runKey = KeyboardController.runKey.ToString();
        data.jumpKey = KeyboardController.jumpKey.ToString();
        data.crouchKey = KeyboardController.crouchKey.ToString();
        data.itemPickUpKey = KeyboardController.itemPickUpKey.ToString();
        data.itemRotateLeftKey = KeyboardController.itemRotateLeftKey.ToString();
        data.itemRotateRightKey = KeyboardController.itemRotateRightKey.ToString();
        data.pauseKey = KeyboardController.pauseKey.ToString();

        //finilize save
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //clears all data by saving null to the location
    public static void clearSave() {

        //get path
        string path = Application.persistentDataPath + "/data.abc";
        BinaryFormatter formatter = new BinaryFormatter();

        //write null using stream
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(null, -1);

        //finalize
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //method to get all data
    public static PlayerData load() {
        string path = Application.persistentDataPath + "/data.abc";
        
        //check if the file exists
        if (File.Exists(path)) {

            //get the stream of data
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data;

            //if not empty
            if (stream.Length != 0) {
                data = formatter.Deserialize(stream) as PlayerData;
            } else {
                data = new PlayerData();
            }

            stream.Close();

            return data;
        } else {
            return null;
        }
    }

    //to get player location in aa Vector3 call: SaveSystem.getPlayerLocation();
    public static Vector3 getPlayerLocation() {
        PlayerData pd = load();
        return new Vector3(pd.position[0], pd.position[1], pd.position[2]);
    }

    //to get the timer as an float, call: SaveSystem.getTimer();
    public static float getTimer() {
        PlayerData pd = load();
        return pd.timer;
    }

    //to automatically update the keybinds call: SaveSystem.loadSettings();
    public static void loadSettings() {
        PlayerData pd = load();

        AudioManager.volumeSetting = pd.volume;
        PlayerController.mouseXSensitivity = pd.sensitivity;

        KeyboardController.runKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.runKey);
        KeyboardController.jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.jumpKey);
        KeyboardController.crouchKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.crouchKey);
        KeyboardController.itemPickUpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.itemPickUpKey);
        KeyboardController.itemRotateLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.itemRotateLeftKey);
        KeyboardController.itemRotateRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.itemRotateRightKey);
        KeyboardController.pauseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), pd.pauseKey);
    }

    //to check if there is a current save call: SaveSystem.isSaved();
    public static bool isSaved() {
        PlayerData pd = load();
        return (pd != null);
    }

}
