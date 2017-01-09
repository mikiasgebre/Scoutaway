using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Resources;
using System.Reflection;

public static class TextManager
{
    public static string FILEPATH = "data";
    public static char[] SPLIT = { '|' };
    public static List<KeyValuePair<string, string[]>> TextStrings;

    //  Key|In English|In Finnish|In Swedish
    /// <summary>
    /// Gets text from Data.dat file. Correct spelling in the file is:  key|text. 
    /// Eg. level1_merchant_1|Welcome to my shop! Use one text per line. If two or more keys are identical, one is picked randomly.
    /// Ignores lines startin with //
    /// </summary>
    /// <param name="key">the key to search for</param>
    /// <returns>Returns Invalid key if the key wasn't found in the file</returns>
    public static string GetText(string key, Language lang)
    {
        if (TextStrings == null)
        {
            ReadFile();
        }

        List<string> strings = new List<string>();
        foreach (KeyValuePair<string, string[]> s in TextStrings)
        {
            if (s.Key == key)
            {
                strings.Add(s.Value[(int)lang]);
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
            Debug.Log("Key " + key + " not found in file " + FILEPATH);
            return "Parse Error : " + key;
        }
    }

    private static void ReadFile()
    {
        TextStrings = new List<KeyValuePair<string, string[]>>();
        {
            StringReader SR = new StringReader(Resources.Load<TextAsset>(FILEPATH).text);
            string lines = SR.ReadLine();
            while (!string.IsNullOrEmpty(lines))
            {
                if (!lines.StartsWith("//"))
                {
                    string[] line = lines.Split(SPLIT, System.StringSplitOptions.RemoveEmptyEntries);
                    if (line.Length > 1)
                    {
                        TextStrings.Add(new KeyValuePair<string, string[]>(line[0], new string[] { line[1], line[2], line[3] }));
                    }
                }

                lines = SR.ReadLine();
            }

            SR.Close();
        }
    }
}