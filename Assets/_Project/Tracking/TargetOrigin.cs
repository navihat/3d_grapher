using System;
using UnityEngine;
using Vuforia;
using Grapher.Core;

namespace Grapher.Tracking
{
    /// <summary>
    /// Thành phần gắn trên ImageTarget của Vuforia để cung cấp Transform gốc O đã chuẩn hóa (1cm = 1 đơn vị).
    /// </summary>
    [RequireComponent(typeof(ObserverBehaviour))]
    public class TargetOrigin : MonoBehaviour, ITargetOrigin
    {
        [Header("Target Identity")]
        [Tooltip("Mã định danh của phiếu bài tập")]
        [SerializeField] private string _targetId = "worksheet_lesson13_01";

        [Header("Coordinate Origin")]
        [Tooltip("Transform gốc O(0,0,0) trùng khít hệ trục in trên giấy")]
        [SerializeField] private Transform _graphRoot;

        private ObserverBehaviour _observer;
        private TrackingState _currentState = TrackingState.Unknown;

        /// <summary>
        /// Sự kiện bắn ra khi trạng thái tracking thay đổi (Tracked, ExtendedTracked, Lost).
        /// </summary>
        public event Action<TrackingStatusChangedEventArgs> OnTrackingStatusChanged;

        public string TargetId => _targetId;

        public Transform OriginTransform => _graphRoot != null ? _graphRoot : transform;

        public bool IsTracked => _currentState == TrackingState.Tracked || _currentState == TrackingState.ExtendedTracked;

        public TrackingState CurrentState => _currentState;

        private void Awake()
        {
            _observer = GetComponent<ObserverBehaviour>();
            if (_observer != null)
            {
                _observer.OnTargetStatusChanged += HandleTargetStatusChanged;
            }
        }

        private void OnDestroy()
        {
            if (_observer != null)
            {
                _observer.OnTargetStatusChanged -= HandleTargetStatusChanged;
            }
        }

        private void HandleTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
        {
            TrackingState newState = ConvertStatus(targetStatus);
            if (newState != _currentState)
            {
                TrackingState oldState = _currentState;
                _currentState = newState;
                OnTrackingStatusChanged?.Invoke(new TrackingStatusChangedEventArgs(_targetId, oldState, newState));
            }
        }

        private TrackingState ConvertStatus(TargetStatus status)
        {
            switch (status.Status)
            {
                case Status.TRACKED:
                    return TrackingState.Tracked;
                case Status.EXTENDED_TRACKED:
                    return TrackingState.ExtendedTracked;
                case Status.NO_POSE:
                case Status.LIMITED:
                    return TrackingState.TrackingLost;
                default:
                    return TrackingState.Unknown;
            }
        }
    }
}
