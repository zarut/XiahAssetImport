using System;
using UnityEngine;

[Serializable]
public class CharacterSkinnedMesh
{
    [SerializeField]
    private byte _isPhysicMesh;
    [SerializeField]
    private uint _skinMeshDataSize;
    [SerializeField]
    private ushort _vertexCount;
    [SerializeField]
    private ushort _facesCount;
    [SerializeField]
    private ushort[] _faces;
    [SerializeField]
    private XiahVTNormal[] _normalVertices;
    [SerializeField]
    private XiahSkinMeshVertex[] _skinMeshVertices;

    public byte IsPhysicMesh
    {
        get
        {
            return _isPhysicMesh;
        }
        set
        {
            _isPhysicMesh = value;
        }
    }
    public UInt32 SkinMeshDataSize
    {
        get
        {
            return _skinMeshDataSize;
        }
        set
        {
            _skinMeshDataSize = value;
        }
    }// Client¿¡¼­ ¹öÆÛ¸¦ Àâ°í ÇÑ¹ø¿¡ ÀÐ±â À§ÇØ.

    public UInt16 VertexCount
    {
        get
        {
            return _vertexCount;
        }
        set
        {
            _vertexCount = value;
        }
    }        // ¹öÅØ½º ¼ö
    public UInt16 FacesCount
    {
        get
        {
            return _facesCount;
        }
        set
        {
            _facesCount = value;
        }
    }          // Face ¼ö

    //IDirect3DVertexBuffer9* vertex_ptr;

    public UInt16[] Faces
    {
        get
        {
            return _faces;
        }
        set
        {
            _faces = value;
        }
    }			// Face ¸®½ºÆ® Lod¿¬»êÀ» À§ÇØ¼­ ÀÌ°Å´Â SystemMemory·Î ¸¸µë


    public XiahVTNormal[] NormalVertices
    {
        get
        {
            return _normalVertices;
        }
        set
        {
            _normalVertices = value;
        }
    }

    public XiahSkinMeshVertex[] SkinMeshVertices
    {
        get
        {
            return _skinMeshVertices;
        }
        set
        {
            _skinMeshVertices = value;
        }
    }
}
