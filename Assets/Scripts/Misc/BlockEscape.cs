using UnityEngine;
using System.Collections.Generic;

public class BlockEscape : MonoBehaviour
{
    public bool Blocking;
    public List<BlockEscape> ScriptsThatBlock;

    protected bool IsBlocked()
    { 
        foreach (BlockEscape be in ScriptsThatBlock)
        {
            if (be.Blocking)
            {
                return true;
            }
        }

        return false;
    }
}
