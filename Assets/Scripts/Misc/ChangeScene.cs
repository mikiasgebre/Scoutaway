using UnityEngine;
using System.Collections;

public class ChangeScene : BlockEscape 
{
    public string SceneName;
    public bool UseEscapeKey;
    public bool SaveBeforeChanging;

    public void Change()
    {
        if (SaveBeforeChanging)
        {
            SaveData.Save();
        }

        Application.LoadLevel(SceneName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UseEscapeKey)
            {
                if (!IsBlocked())
                {
                    Change();
                }
            }
        }
    }

    private IEnumerator SleepForAFrame()
    {
        yield return new WaitForEndOfFrame();
        
    }

    public void Change(string Name)
    {
        Application.LoadLevel(Name);
    }
}
