using System;
using UnityEngine;

[Serializable]
public class CharacterTimerTrigger
{
    [SerializeField]
    private ushort _nType;
    [SerializeField]
    private ushort _nStartTime;
    [SerializeField]
    private ushort _nLength;

    public UInt16 nType
    {
        get
        {
            return _nType;
        }
        set
        {
            _nType = value;
        }
    }
    public UInt16 nStartTime
    {
        get
        {
            return _nStartTime;
        }
        set
        {
            _nStartTime = value;
        }
    }
    public UInt16 nLength
    {
        get
        {
            return _nLength;
        }
        set
        {
            _nLength = value;
        }
    }
}
