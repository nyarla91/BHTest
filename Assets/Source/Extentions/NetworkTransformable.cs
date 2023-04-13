using System;
using Mirror;
using UnityEngine;

namespace Source.Extentions
{
    public class NetworkTransformable : NetworkBehaviour
    {
        private Transform _transform;
        public Transform Transform => _transform ??= gameObject.transform;
        
        [Obsolete("Use Transform cached property instead")] public new Transform transform => Transform;
    }
}