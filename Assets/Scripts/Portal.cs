using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer renderer;

    UnityEngine.Camera camera;
    Transform playerCamera;

    private void Start()
    {
        camera = GetComponentInChildren<UnityEngine.Camera>();
        playerCamera = UnityEngine.Camera.main.transform;

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        camera.targetTexture = rt;
        linkedPortal.renderer.material.SetTexture("_MainTex", rt);
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            linkedPortal.transform.worldToLocalMatrix *
            playerCamera.localToWorldMatrix;

        camera.transform.SetPositionAndRotation(m.GetPosition(), m.rotation);
    }
}
