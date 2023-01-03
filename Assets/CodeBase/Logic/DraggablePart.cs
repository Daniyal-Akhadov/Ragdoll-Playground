using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(TargetJoint2D))]
    public class DraggablePart : MonoBehaviour
    {
        [SerializeField] private float _massMultiplier = 3f;

        private Camera _camera;
        private Vector2 _difference;
        private TargetJoint2D _targetJoint;
        private float _originalMass;

        private Vector2 WorldPoint => _camera.ScreenToWorldPoint(Input.mousePosition);

        private void Awake()
        {
            _targetJoint = GetComponent<TargetJoint2D>();
            _camera = Camera.main;
            _originalMass = _targetJoint.attachedRigidbody.mass;
        }

        private void Start()
        {
            DisableDrag();
        }

        private void OnMouseDown()
        {
            EnableDrag();
            SetMass(_originalMass * _massMultiplier);
        }

        private void OnMouseDrag()
        {
            DoDrag();
        }

        private void OnMouseUp()
        {
            DisableDrag();
            SetMass(_originalMass);
        }

        private void DoDrag()
        {
            _targetJoint.target = WorldPoint;
        }

        private void EnableDrag()
        {
            _targetJoint.enabled = true;
        }

        private void DisableDrag()
        {
            _targetJoint.enabled = false;
        }

        private void SetMass(float mass)
        {
            _targetJoint.attachedRigidbody.mass = mass;
        }
    }
}