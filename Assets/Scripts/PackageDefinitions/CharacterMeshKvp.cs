
using System;
using UnityEngine;

[Serializable]
public class CharacterMeshKvp
{
    [SerializeField]
    private Int32 meshType;
    [SerializeField]
    private CharacterMeshDefinition meshDefinition;

    public Int32 MeshType
    {
        get { return meshType; }
        set { meshType = value; }
    }

    public CharacterMeshDefinition MeshDefinition
    {
        get { return meshDefinition; }
        set { meshDefinition = value; }
    }

}
