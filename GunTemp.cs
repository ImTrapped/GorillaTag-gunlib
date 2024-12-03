dependencies are these
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static NetworkSystem;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;


below is the gun lib and a example
feel free to use it



    internal class GunTemp
    {
       

      
        public static (RaycastHit Ray, GameObject NewPointer) MakeGun()
        {
            GunShape = PrimitiveType.Sphere; //default gunshape for most

            Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position  , GorillaTagger.Instance.rightHandTransform.forward, out var Ray, 512f);

            GameObject GunPointer = GameObject.CreatePrimitive(GunShape);
            GunPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            GunPointer.GetComponent<Renderer>().material.color = (RigHit || (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f)) ? Color.cyan : Color.cyan;
            GunPointer.transform.localScale =  new Vector3(0.1f, 0.1f, 0.1f);
            GunPointer.transform.position = RigHit ? RigLockedDown.transform.position : Ray.point;
            if (disableGunPointer)
            {
                GunPointer.GetComponent<Renderer>().enabled = false;
            }
            UnityEngine.Object.Destroy(GunPointer.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(GunPointer.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(GunPointer.GetComponent<Collider>());
            UnityEngine.Object.Destroy(GunPointer, Time.deltaTime);

            if (!disableGunLine)
            {
                GameObject Gunline = new GameObject("Gun Render");
                LineRenderer GunlineRender = Gunline.AddComponent<LineRenderer>();
                GunlineRender.material.shader = Shader.Find("GUI/Text Shader");
                GunlineRender.startColor = Color.blue;    //line start color
                GunlineRender.endColor = Color.white;     //line end color
                GunlineRender.startWidth = 0.03f;        //starting width
                GunlineRender.endWidth = 0.03f;          //ending width
                GunlineRender.positionCount = 2;
                GunlineRender.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                GunlineRender.SetPosition(1, RigHit ? RigLockedDown.transform.position : Ray.point);
                UnityEngine.Object.Destroy(Gunline, Time.deltaTime);
            }

            return (Ray, GunPointer);
        }

        //gun visuals
        public static bool disableGunPointer = false;
        public static bool disableGunLine = false;
        
        //rig stuff
        public static bool RigHit = false;
        public static VRRig RigLockedDown = null;
        
        //gun shape
        public static PrimitiveType GunShape; //gunshap, you can set this to anything you want
    }
}

//below is a example of how to make a gun (this does not work, this is for documentation only)

/*
public static void WaterGun()
{
    if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed) //right grab creats the line and gunpointer
    {
        var GunData = MakeGun();
        RaycastHit Ray = GunData.Ray;
        GameObject GunPointer = GunData.NewPointer;

        if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f)  //right trigger (while holding right grab) carrys out the action below
        {
            
            if (Time.time > Delay)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("FAKE_RPC", RpcTarget.All, new object[]    //in this example it is using a rpc (i replaced it to a fake one)
                {
                            args
                });
               
                Delay = Time.time + 0.1f;
            }
        }
        else
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }
    }
}
*/ 
//i am a ai because above is acaully how i talk :skull:
