using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine.UI;

public abstract class Operation
{
    [XmlIgnore]
    public abstract string Name { get; }
    [HideInInspector]
    [XmlIgnore]
    public bool doact;
    [XmlIgnore]
    public static OperationPanelControl OPC;
    public static SceneManager SceneManager;
    public static string InfoText;
    //public Text InfoText;
    public virtual void Execute()
    {
        /*if (infoText == null)
        {
            infoText = GameObject.FindObjectOfType<UIbar>().InfoText;
        }*/
        if (OPC == null)
        {
            OPC = GameObject.FindObjectOfType<OperationPanelControl>();
        }

        if (SceneManager == null)
        {
            SceneManager = GameObject.FindObjectOfType<SceneManager>();
        }

        if (GameObject.FindObjectOfType<OperationPanelControl>().Act.OperationsAvailable > 0)
        {
            doact = true;
        }
        else
        {
            doact = false;
        }
        SaveData.Save();
    }

}
