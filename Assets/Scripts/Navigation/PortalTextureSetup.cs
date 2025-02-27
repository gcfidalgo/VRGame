using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	public Camera cameraA;
	public Camera cameraB;

	public Material cameraMatA;
	public Material cameraMatB;

	public Camera camera3; 
	public Material cameraMat3;
    public Camera camera4;
    public Material cameraMat4;
    public Camera camera5;
    public Material cameraMat5;
    public Camera camera6;
    public Material cameraMat6;

    public Camera camera7;
    public Material cameraMat7;
    public Camera camera8;
    public Material cameraMat8;

    public Camera camera9;
    public Material cameraMat9;
    public Camera camera10;
    public Material cameraMat10;

    // Use this for initialization
    void Start () {

        //set 1
		if (cameraA.targetTexture != null)
		{
			cameraA.targetTexture.Release();
		}
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatA.mainTexture = cameraA.targetTexture;

		if (cameraB.targetTexture != null)
		{
			cameraB.targetTexture.Release();
		}
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatB.mainTexture = cameraB.targetTexture;

        //set 2
        if (camera3.targetTexture != null)
        {
            camera3.targetTexture.Release();
        }
        camera3.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat3.mainTexture = camera3.targetTexture;

        if (camera4.targetTexture != null)
        {
            camera4.targetTexture.Release();
        }
        camera4.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat4.mainTexture = camera4.targetTexture;

        //set3
        if (camera5.targetTexture != null)
        {
            camera5.targetTexture.Release();
        }
        camera5.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat5.mainTexture = camera5.targetTexture;

        if (camera6.targetTexture != null)
        {
            camera6.targetTexture.Release();
        }
        camera6.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat6.mainTexture = camera6.targetTexture;

        //set4
        if (camera7.targetTexture != null)
        {
            camera7.targetTexture.Release();
        }
        camera7.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat7.mainTexture = camera7.targetTexture;

        if (camera8.targetTexture != null)
        {
            camera8.targetTexture.Release();
        }
        camera8.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat8.mainTexture = camera8.targetTexture;

        //set5
        if (camera9.targetTexture != null)
        {
            camera9.targetTexture.Release();
        }
        camera9.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat9.mainTexture = camera9.targetTexture;

        if (camera10.targetTexture != null)
        {
            camera10.targetTexture.Release();
        }
        camera10.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat10.mainTexture = camera10.targetTexture;
    }
	
}
