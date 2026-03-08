using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterPackageMeshGenerator : MonoBehaviour
{
    private Transform _meshGeneratorObjectTransform;

    [SerializeField]
    private string PackageFile;
    [SerializeField]
    private CharacterPackageContainer[] drawnPackageContainers;
    [SerializeField]
    private Material _defaultMaterial;

    private void Awake()
    {
        this._meshGeneratorObjectTransform = this.GetComponent<Transform>();
    }

    private void Start()
    {
        XiahXpcLoader xiahXpcLoader = new XiahXpcLoader();
        CharacterPackageContainer[] importedContainers = xiahXpcLoader.LoadXiahCharacterPackage(PackageFile);
        this.drawnPackageContainers = importedContainers;

        this.GenerateForPackageContainers(importedContainers);
    }

    private void GenerateForPackageContainers(CharacterPackageContainer[] characterPackageContainers)
    {
        for (int i = 0; i < characterPackageContainers.Length; i++)
        {
            CharacterPackageContainer characterPackageContainer = characterPackageContainers[i];
            this.GenerateAllMeshesForPackageContainer(characterPackageContainer);
        }
    }

    private void GenerateAllMeshesForPackageContainer(CharacterPackageContainer characterPackageContainer)
    {
        GameObject characterPackageContainerObject = new GameObject();
        characterPackageContainerObject.name = "Character id " + characterPackageContainer.CharacterId.ToString();

        Transform characterPackageContainerTransform = characterPackageContainerObject.GetComponent<Transform>();
        characterPackageContainerTransform.SetParent(this._meshGeneratorObjectTransform);

        for (int i = 0; i < characterPackageContainer.MeshDefinitionsKvps.Length; i++)
        {
            CharacterMeshDefinition characterMeshDefinition = characterPackageContainer.MeshDefinitionsKvps[i].MeshDefinition;
            this.GenerateFullMeshForDefinition(characterMeshDefinition, characterPackageContainerTransform);
        }
    }

    private void GenerateFullMeshForDefinition(CharacterMeshDefinition characterMeshDefinition, Transform parentTransform)
    {
        GameObject meshDefinitionObject = new GameObject();
        meshDefinitionObject.name = "Mesh type " + characterMeshDefinition.MeshType.ToString();

        Transform meshDefinitionTransform = meshDefinitionObject.GetComponent<Transform>();
        meshDefinitionTransform.SetParent(parentTransform);

        for (int i = 0; i < characterMeshDefinition.CharacterSkinnedMeshesCount; i++)
        {
            CharacterSkinnedMesh characterSkinnedMesh = characterMeshDefinition.CharacterSkinnedMeshes[i];
            this.GenerateMeshObjectForSkinnedMesh(characterSkinnedMesh, meshDefinitionTransform);
        }
    }

    private void GenerateMeshObjectForSkinnedMesh(CharacterSkinnedMesh characterSkinnedMesh, Transform parentTransform)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        Vector3[] verticesArray;
        Vector3[] normalsArray;

        if (characterSkinnedMesh.IsPhysicMesh > 0)
        {
            foreach (var skinMeshVertex in characterSkinnedMesh.SkinMeshVertices)
            {
                float positionX = skinMeshVertex.Position[0];
                float positionY = skinMeshVertex.Position[1];
                float positionZ = skinMeshVertex.Position[2];

                Vector3 positionVector = new Vector3(positionX, positionY, positionZ);
                vertices.Add(positionVector);

                float normalX = skinMeshVertex.Normal[0];
                float normalY = skinMeshVertex.Normal[1];
                float normalZ = skinMeshVertex.Normal[2];

                Vector3 normalVector = new Vector3(normalX, normalY, normalZ);
                normals.Add(normalVector);
            }
        }
        else
        {
            foreach (var normalVertex in characterSkinnedMesh.NormalVertices)
            {
                float positionX = normalVertex.Position[0];
                float positionY = normalVertex.Position[1];
                float positionZ = normalVertex.Position[2];

                Vector3 positionVector = new Vector3(positionX, positionY, positionZ);
                vertices.Add(positionVector);

                float normalX = normalVertex.Normal[0];
                float normalY = normalVertex.Normal[1];
                float normalZ = normalVertex.Normal[2];

                Vector3 normalVector = new Vector3(normalX, normalY, normalZ);
                normals.Add(normalVector);
            }
        }

        verticesArray = vertices.ToArray();
        normalsArray = normals.ToArray();
        int[] triangles = characterSkinnedMesh.Faces.Select(face => (int)face).ToArray();
        
        normalsArray = normals.ToArray();
        
        Mesh generatedMesh = new Mesh();
        generatedMesh.vertices = verticesArray;
        generatedMesh.triangles = triangles;
        generatedMesh.normals = normalsArray;
        //generatedMesh.RecalculateNormals();
        
        GameObject skinnedMeshGameObject = new GameObject();
        Transform skinnedMeshObjectTransform = skinnedMeshGameObject.GetComponent<Transform>();
        skinnedMeshObjectTransform.SetParent(parentTransform);

        MeshFilter meshFilter = skinnedMeshGameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = generatedMesh;

        MeshRenderer skinnedMeshRenderer = skinnedMeshGameObject.AddComponent<MeshRenderer>();
        skinnedMeshRenderer.material = this._defaultMaterial;
    }
}
