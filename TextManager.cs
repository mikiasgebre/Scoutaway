using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class TextManager
{
    public static string FILEPATH = Application.dataPath + "/Data.dat";
    public static char[] SPLIT = { '|' };
    public static Encoding ENCODING = Encoding.UTF8;
    public static List<KeyValuePair<string, string>> TextStrings;

    /// <summary>
    /// Gets text from Data.dat file. Correct spelling in the file is key|text. 
    /// Eg. level1_merchant_1|Welcome to my shop! Use one text per line. If two or more keys are identical, one is picked randomly.
    /// </summary>
    /// <param name="key">the key to search for</param>
    /// <returns>Returns Invalid key if the key wasn't found in the file</returns>
    public static string GetText(string key)
    {
        if (TextStrings == null)
        {
            ReadFile();
        }

        List<string> strings = new List<string>();
        foreach (KeyValuePair<string, string> s in TextStrings)
        {
            if (s.Key == key)
            {
                strings.Add(s.Value);
            }
        }

        if (strings.Count == 1)
        {
            return strings[0];
        }
        else if (strings.Count > 1)
        {
            return strings[Random.Range(0, strings.Count)];
        }
        else
        {
            Debug.Log("Key not found in file " + FILEPATH);
            return "Parse Error" + FILEPATH;
        }
    }

    private static void ReadFile()
    {
        TextStrings = new List<KeyValuePair<string, string>>();
        if (File.Exists(FILEPATH))
        {
            StreamReader SR = new StreamReader(FILEPATH, ENCODING);
            while (!SR.EndOfStream)
            {
                try
                {
                    string[] line = SR.ReadLine().Split(SPLIT, System.StringSplitOptions.RemoveEmptyEntries);
                    if (line.Length > 1)
                    {
                        TextStrings.Add(new KeyValuePair<string, string>(line[0], line[1]));
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.Log("Unable to read file " + FILEPATH + ". " + ex.Message);
                }
            }

            SR.Close();
        }
    }
}