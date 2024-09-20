using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrame : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Material ghostMaterial;
    public float ghostLifeTime = 0.5f;
    public float fadeSpeed = 1f;

    public void CreateGhost() {
        GameObject ghost = new GameObject("Ghost");
        MeshFilter meshFilter = ghost.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = ghost.AddComponent<MeshRenderer>();

        Mesh bakedMesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(bakedMesh);

        meshFilter.mesh = bakedMesh;
        meshRenderer.materials = skinnedMeshRenderer.materials;

        ghost.transform.position = skinnedMeshRenderer.transform.position;
        ghost.transform.rotation = skinnedMeshRenderer.transform.rotation;
        ghost.transform.localScale = skinnedMeshRenderer.transform.localScale;

        StartCoroutine(FadeAndDestroy(ghost, meshRenderer));
    }

    private IEnumerator FadeAndDestroy(GameObject ghost, MeshRenderer meshRenderer) {

        yield return new WaitForSeconds(1f);

        Destroy(ghost);
    }
}
