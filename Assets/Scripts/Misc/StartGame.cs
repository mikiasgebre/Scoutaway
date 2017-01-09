using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
    public enum StartType { New, Continue }
    public StartType start;


    public void Game()
    {
        if (start == StartType.Continue)
        {
            SaveData.Load();
            Application.LoadLevel("CharacterSelection");
        }
        else
        {
            SaveData.Clear();
            Application.LoadLevel("CharacterSelection");
        }
        

    }
}
