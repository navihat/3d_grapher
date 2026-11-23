using System;
using UnityEngine;

namespace Grapher.Tracking
{
    public enum TrackingState
    {
        Unknown,
        TrackingLost,
        Tracked,
        ExtendedTracked
    }

    /// <summary>
    /// Dữ liệu sự kiện thay đổi trạng thái tracking của marker.
    /// </summary>
    [Serializable]
    public struct TrackingStatusChangedEventArgs
    {
        public string TargetId;
        public TrackingState PreviousState;
        public TrackingState CurrentState;

        public TrackingStatusChangedEventArgs(string targetId, TrackingState previousState, TrackingState currentState)
        {
            TargetId = targetId;
            PreviousState = previousState;
            CurrentState = currentState;
        }
    }
}
