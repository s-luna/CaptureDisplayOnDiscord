using UnityEngine;
using System.Collections;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private GameObject m_moniterObject;
    private Material m_material;

    void Start()
    {
        m_material = m_moniterObject.GetComponent<MeshRenderer>().material;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(null, null, m_material);
    }
}