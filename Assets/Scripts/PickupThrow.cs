using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityStandardAssets.Utility // This is a modified version of the Standard Assets script. The old namespace has been kept.
{
    public class DragThrowRigidbody : MonoBehaviour
    {
        const float c_SpringForce = 100.0f;
        const float c_DamperForce = 0.0f;
        const float c_LinearDamping = 10.0f;
        const float c_AngularDamping = 5.0f;
        const float c_MaxDistance = 0.2f;
        const float c_MinDistance = 1.5f;
        [SerializeField] private float LaunchPower = 5f;

        private SpringJoint GrabSpringJoint;
        private float OldLinearDamping = 1f;
        private float OldAngularDamping = 1f;
        private GameObject HeldObject;
        private float GrabCooldownTimer = 0f;


        public PlayerInput _playerInput;
        public InputAction PlayerPickUp;
        public InputAction PlayerThrow;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            PlayerPickUp = _playerInput.actions["PickUp"];
            PlayerThrow = _playerInput.actions["Throw"];
        }

        private void Update()
        {
            if (GrabCooldownTimer > 0)
            {
                //Debug.Log(GrabCooldownTimer);
                GrabCooldownTimer -= Time.deltaTime;
                return;
            }

            if (!PlayerPickUp.IsPressed()) //Make sure the user pressed the mouse down
            {
                return;
            }

            var mainCamera = Camera.main;

            // We need to actually hit an object
            RaycastHit hit = new RaycastHit();
            if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin, mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 3, Physics.DefaultRaycastLayers))
            {
                return;
            }

            // We need to hit a rigidbody that is not kinematic
            if (!hit.rigidbody || hit.rigidbody.isKinematic)
            {
                return;
            }

            if (!GrabSpringJoint)
            {
                var go = new GameObject("Rigidbody dragger");
                Rigidbody body = go.AddComponent<Rigidbody>();
                GrabSpringJoint = go.AddComponent<SpringJoint>();
                body.isKinematic = true;
                // parent Rigidbody dragger to the box
                //go.transform.parent = box;
            }

            //GrabSpringJoint.transform.position = hit.point;
            HeldObject = hit.transform.gameObject;
            GrabSpringJoint.transform.position = hit.transform.gameObject.GetComponent<Renderer>().bounds.center;
            GrabSpringJoint.anchor = Vector3.zero;

            GrabSpringJoint.spring = c_SpringForce;
            GrabSpringJoint.damper = c_DamperForce;
            GrabSpringJoint.maxDistance = c_MaxDistance;
            GrabSpringJoint.connectedBody = hit.rigidbody;
            OldLinearDamping = GrabSpringJoint.connectedBody.linearDamping;
            OldAngularDamping = GrabSpringJoint.connectedBody.angularDamping;
            StartCoroutine("DragThrowObject", hit.distance);
        }

        private IEnumerator DragThrowObject(float distance)
        {
            if (distance < c_MinDistance)
            {
                distance = c_MinDistance;
            }
            GrabSpringJoint.connectedBody.linearDamping = c_LinearDamping;
            GrabSpringJoint.connectedBody.angularDamping = c_AngularDamping;
            var mainCamera = Camera.main;

            while (PlayerPickUp.IsPressed())
            {
                //Debug.Log("m_sprintJoint " + m_SpringJoint.name);
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                GrabSpringJoint.transform.position = ray.GetPoint(distance);
                //Debug.Log("Layer: " + m_SpringJoint.transform.gameObject.layer);
                HeldObject.layer = 6;
                //Debug.Log("Layer: " + m_SpringJoint.transform.gameObject.layer);

                //m_SpringJoint.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Picked Up");


                if (PlayerThrow.IsPressed()) // Throw code. We simply add an impulse force to the object, set its drag back to normal, disconnect it from the spring joint, and stop the coroutine.
                {
                    Vector3 throwPower = new Vector3(LaunchPower, LaunchPower, LaunchPower);
                    GrabSpringJoint.connectedBody.AddForce(Vector3.Scale(ray.direction, throwPower), ForceMode.Impulse);
                    ReleaseDraggedBody();
                    yield break;
                }
                yield return null;
            }
            if (GrabSpringJoint.connectedBody)
            {
                ReleaseDraggedBody();
            }
        }

        private void ReleaseDraggedBody()
        {
            GrabSpringJoint.connectedBody.linearDamping = OldLinearDamping;
            GrabSpringJoint.connectedBody.angularDamping = OldAngularDamping;
            GrabSpringJoint.connectedBody = null;
            HeldObject.layer = 0;
            GrabCooldownTimer = 0.5f;
            //Debug.Log("Layer: " + m_SpringJoint.transform.gameObject.layer);
            //m_SpringJoint.transform.gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
