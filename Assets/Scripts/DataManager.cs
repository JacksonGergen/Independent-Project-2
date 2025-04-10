using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

public class DataManager : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;
    private string _xmlLevelProgress;
    private string _xmlWeapons;

    private List<Weapon> weaponInventory = new List<Weapon>
    {
        new Weapon("Sword of Doom", 100),
        new Weapon("Axe of Destiny", 150),
        new Weapon("Mace of Justice", 200)
    };

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Data Manager initialized..";
        Debug.Log(_state);
        FileSystemInfo();
        NewDirectory();
        WriteToXML(_xmlLevelProgress);
        /*
        NewTextFile();
        UpdateTextFile();
        ReadFromFile(_textFile);
        */
        WriteToStream(_streamingTextFile);
        ReadFromStream(_streamingTextFile);
    }

    public void FileSystemInfo()
    {
        Debug.LogFormat("Path separator character: {0}",
                        Path.PathSeparator);
        Debug.LogFormat("Directory separator character: {0}",
                        Path.DirectorySeparatorChar);
        Debug.LogFormat("Current directory: {0}",
                        Directory.GetCurrentDirectory());
        Debug.LogFormat("Temporary path: {0}",
                        Path.GetTempPath());
    }

    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";
        Debug.Log(_dataPath);
        _textFile = _dataPath + "Save_Data.txt";
        _streamingTextFile = _dataPath + "Streaming_Save_Data.txt";
        _xmlLevelProgress = _dataPath + "Progress_Data.xml";
        _xmlWeapons = _dataPath + "WeaponInventory.xml";
    }

    public void NewDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log("Directory already exists!");
            return;
        }
        Directory.CreateDirectory(_dataPath);
        Debug.Log("New directory created!");
    }

    public void DeleteDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log("Directory doesn't exist or has already been deleted!");
            return;
        }
        Directory.Delete(_dataPath, true);
        Debug.Log("Directory deleted!");
    }

    public void NewTextFile()
    {
        if (File.Exists(_textFile))
        {
            Debug.Log("File already exists!");
            return;
        }
        File.WriteAllText(_textFile, "<Save Data>");
        Debug.Log("New text file created!");
    }

    public void UpdateTextFile()
    {
        if (!File.Exists(_textFile))
        {
            Debug.Log("File doesn't exist!");
            return;
        }
        File.AppendAllText(_textFile, $"Game Started: {DateTime.Now}\n");
        Debug.Log("Text file updated!");
    }

    public void ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist!");
            return;
        }
        Debug.Log(File.ReadAllText(filename));
    }

    public void DeleteFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist or has already been deleted!");
            return;
        }
        File.Delete(filename);
        Debug.Log("File deleted!");
    }

    public void WriteToStream(string filename)
    {
        if (!File.Exists(filename))
        {
            StreamWriter newStream = File.CreateText(filename);
            newStream.WriteLine("<Save Data> for HERO BORN \n");
            newStream.Close();
            Debug.Log("New file created with StreamWriter!");
        }
        StreamWriter streamWriter = File.AppendText(filename);
        streamWriter.WriteLine($"Game Ended: {DateTime.Now}");
        streamWriter.Close();
        Debug.Log("File contents updated with StreamWriter!");
    }

    public void ReadFromStream(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist!");
            return;
        }
        StreamReader streamReader = new StreamReader(filename);
        Debug.Log(streamReader.ReadToEnd());
    }

    public void WriteToXML(string filename)
    {
        if (!File.Exists(filename))
        {
            FileStream xmlStream = File.Create(filename);
            XmlWriter xmlWriter = XmlWriter.Create(xmlStream);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("level_progress");
            for (int i = 1; i < 5; i++)
            {
                xmlWriter.WriteElementString("level", "Level-" + i);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
            xmlStream.Close();
        }
    }
}
