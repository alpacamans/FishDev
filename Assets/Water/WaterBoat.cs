using Ditzelgames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterFloat))]
public class WaterBoat : MonoBehaviour
{

    //visible Properties

    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;


    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected ParticleSystem ParticleSystem;
    protected Camera Camera;

    //internal Properties
    protected Vector3 CamVel;


    public void Awake()
    {
         ParticleSystem = GetComponentInChildren<ParticleSystem>();
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
        //Camera = Camera.main;
    }

    public void FixedUpdate()
    {
        if (!ButtonText.BoatSet&& GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().isTouch)
        {
            //default direction
            var forceDirection = transform.forward;
            var steer = 0.0f;

            //steer direction [-1,0,1]
            if (GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.y > 0)
            {
                steer = 1f * GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.x * -1;
            }
            else if(GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.y < 0)
            {
                steer = 1f * GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.x * 1;

            }


            //Rotational Force

            Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 1000f, Motor.position);

            //compute vectors
            var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
            var targetVel = Vector3.zero;

            //forward/backward poewr

            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed* GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.y, Power);
         
            //Motor Animation // Particle system
            Motor.SetPositionAndRotation(Motor.position, transform.rotation * StartRotation * Quaternion.Euler(0, 30f * steer, 0));
            if (ParticleSystem != null)
            {
                if (GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.y>0 || GameObject.Find("JoyStickBackground").GetComponent<JoyStick>().value.y<0)
                    ParticleSystem.Play();
                else
                    ParticleSystem.Pause();
            }

            //moving forward
            var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;

            //move in direction
            Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;

            //camera position
            //Camera.transform.LookAt(transform.position + transform.forward * 6f + transform.up * 2f);
            //Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, transform.position + transform.forward * -8f + transform.up * 2f, ref CamVel, 0.05f);
        }
    }

}