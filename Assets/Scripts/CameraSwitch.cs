using UnityEngine;
//using System.Collections;

public class CameraSwitch : MonoBehaviour {
    private bool oldCulling;
    // Use this for initialization
    void Start () {
        MirrorFlipCamera(gameObject.GetComponent<Camera>());
        
    }

    void MirrorFlipCamera(Camera camera)
    {
        //摄像机镜像翻转
        Matrix4x4 m = new Matrix4x4();
        m.m00 = -1;
        m.m11 = 1;
        m.m22 = 1;
        m.m33 = 1;
        camera.projectionMatrix *= m;
    }
    void OnPreRender()
    {
        //GL.SetRevertBackfacing(true);
        oldCulling = GL.invertCulling;
        GL.invertCulling = true;
    }
    void OnPostRender()
    {
        //GL.SetRevertBackfacing(false);
        GL.invertCulling = oldCulling;
    }
}
