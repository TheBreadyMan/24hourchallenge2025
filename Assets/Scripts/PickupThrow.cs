using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityStandardAssets.Utility // This is a modified version of the Standard Assets script. The old namespace has been kept.
{
    public class PickUpThrow : MonoBehaviour
    {
        const float c_SpringForce = 100.0f;
        const float c_DamperForce = 0.0f;
        const float c_LinearDamping = 10.0f;
        const float c_AngularDamping = 5.0f;
        const float c_MaxDistance = 0.2f;
        const float c_MinDistance = 1.5f;
        [SerializeField] private float LaunchPower = 1f;

        private SpringJoint GrabSpringJoint;
        private float OldLinearDamping = 1f;
        private float OldAngularDamping = 1f;
        private GameObject HeldObject;
        private float GrabCooldownTimer = 0f;
        private bool FirstLoop = true;

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
                GrabCooldownTimer -= Time.deltaTime;
                return;
            }

            if (!PlayerPickUp.IsPressed()) //Make sure the user pressed the mouse down
            {
                return;
            }

            var mainCamera = Camera.main;

            RaycastHit hit = new RaycastHit();
            if (!Physics.Raycast(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()).origin, mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()).direction, out hit, 3, Physics.DefaultRaycastLayers))
            {
                return;
            }

            if (!hit.rigidbody || hit.rigidbody.isKinematic) // We need to hit a rigidbody that is not kinematic
            {
                return;
            }

            if (!GrabSpringJoint)
            {
                var go = new GameObject("Rigidbody Dragger");
                Rigidbody body = go.AddComponent<Rigidbody>();
                GrabSpringJoint = go.AddComponent<SpringJoint>();
                body.isKinematic = true;
            }

            HeldObject = hit.transform.gameObject;
            GrabSpringJoint.transform.position = hit.transform.gameObject.GetComponent<Renderer>().bounds.center;
            GrabSpringJoint.anchor = Vector3.zero;

            GrabSpringJoint.spring = c_SpringForce;
            GrabSpringJoint.damper = c_DamperForce;
            GrabSpringJoint.maxDistance = c_MaxDistance;
            GrabSpringJoint.connectedBody = hit.rigidbody;

            if (FirstLoop)
            {
                OldLinearDamping = GrabSpringJoint.connectedBody.linearDamping;
                OldAngularDamping = GrabSpringJoint.connectedBody.angularDamping;
                FirstLoop = false;
            }

            StartCoroutine("DragThrowObject", hit.distance);
        }

        private IEnumerator DragThrowObject(float distance)
        {
            if (distance < c_MinDistance)
            {
                distance = c_MinDistance;
            }
            var mainCamera = Camera.main;
            var rb = GrabSpringJoint.connectedBody;

            rb.linearDamping = c_LinearDamping;
            rb.angularDamping = c_AngularDamping;


            while (PlayerPickUp.IsPressed())
            {
                var ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                GrabSpringJoint.transform.position = ray.GetPoint(distance);
                HeldObject.layer = 6;


                if (PlayerThrow.IsPressed()) // Throw code. We simply add an impulse force to the object, set its drag back to normal, disconnect it from the spring joint, and stop the coroutine.
                {
                    Vector3 throwPower = new Vector3(LaunchPower, LaunchPower, LaunchPower);
                    rb.AddForce(Vector3.Scale(ray.direction, throwPower), ForceMode.Impulse);
                    ReleaseDraggedBody(rb);
                    yield break;
                }
                yield return null;
            }
            if (rb)
            {
                ReleaseDraggedBody(rb);
            }
        }

        private void ReleaseDraggedBody(Rigidbody rb)
        {
            rb.linearDamping = OldLinearDamping;
            rb.angularDamping = OldAngularDamping;
            GrabSpringJoint.connectedBody = null;
            HeldObject.layer = 0;
            GrabCooldownTimer = 0.5f;
            FirstLoop = true;
        }
    }
}
