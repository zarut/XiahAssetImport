using System;
using UnityEngine;

//---------------------------------------------------------------------------------------
// XYZ | NORMAL | TEX2
[Serializable]
public class XiahVTNormal
{
    [SerializeField]
    private Vector3 _position;
    [SerializeField]
    private Vector3 _normal;
    [SerializeField]
    private Vector2 _texture;

    public Vector3 Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
        }
    }
    public Vector3 Normal
    {
        get
        {
            return _normal;
        }
        set
        {
            _normal = value;
        }
    }
    public Vector2 Texture
    {
        get
        {
            return _texture;
        }
        set
        {
            _texture = value;
        }
    }

    // Total size of all components for file reading purposes: 8 floats = 8*(4 bytes) = 32 bytes
}
