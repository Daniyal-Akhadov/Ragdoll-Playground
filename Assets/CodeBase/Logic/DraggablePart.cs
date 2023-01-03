using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(TargetJoint2D))]
    public class DraggablePart : MonoBehaviour
    {
        private Camera _camera;
        private Vector2 _difference;
        private TargetJoint2D _targetJoint;

        private Vector2 WorldPoint => _camera.ScreenToWorldPoint(Input.mousePosition);

        private void Awake()
        {
            _camera = Camera.main;
            _targetJoint = GetComponent<TargetJoint2D>();
        }

        private void Start()
        {
            DisableDrag();
        }

        private void OnMouseDown()
        {
            EnableDrag();
        }

        private void OnMouseDrag()
        {
            DoDrag();
        }

        private void OnMouseUp()
        {
            DisableDrag();
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
    }
}