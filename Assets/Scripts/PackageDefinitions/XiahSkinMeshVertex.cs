
using System;
using UnityEngine;

//---------------------------------------------------------------------------------------
// XYZB2 | BYTE4 | NORMAL | TEX2
[Serializable]
public class XiahSkinMeshVertex
{
    public const int PositionArraySize = 3;
    public const int WeightArraySize = 3;
    public const int NormalArraySize = 3;
    public const int TextureArraySize = 2;

    [SerializeField]
    private float[] _position;
    [SerializeField]
    private float[] _weight;
    [SerializeField]
    private uint _indices;
    [SerializeField]
    private float[] _normal;
    [SerializeField]
    private float[] _texture;

    public float[] Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
        }
    }      // À§Ä¡
    public float[] Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            _weight = value;
        }
    }           // Blend Weight
    public UInt32 indices
    {
        get
        {
            return _indices;
        }
        set
        {
            _indices = value;
        }
    }          // Blend Matrix Index
    public float[] Normal
    {
        get
        {
            return _normal;
        }
        set
        {
            _normal = value;
        }
    }           // Normal
    public float[] Texture
    {
        get
        {
            return _texture;
        }
        set
        {
            _texture = value;
        }
    }			// TextureÁÂÇ¥

    public XiahSkinMeshVertex()
    {
        Position = new float[XiahSkinMeshVertex.PositionArraySize];
        Weight = new float[XiahSkinMeshVertex.WeightArraySize];
        Normal = new float[XiahSkinMeshVertex.NormalArraySize];
        Texture = new float[XiahSkinMeshVertex.TextureArraySize];
    }

    // Total size of all components for file reading purposes: 11 floats + 1 UInt32 = 11*(4 bytes) + 4 bytes = 48 bytes
}
