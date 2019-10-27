﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FixedPointy;
using TF.Core;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TF.Colliders
{
    public class TFCircleCollider : TFCollider
    {
        public Fix radius;

        // Used when we only change position.
        public override void MoveAABB(FixVec2 posDiff)
        {
            boundingBox.min._x += posDiff.X;
            boundingBox.min._y += posDiff.Y;
            boundingBox.max._x += posDiff.X;
            boundingBox.max._y += posDiff.Y;
        }

        // Used when we rotate or radius is changed.
        public override void RecalcAABB(FixVec2 pos)
        {
            boundingBox.min._x = -radius + pos.X;
            boundingBox.min._y = -radius + pos.Y;
            boundingBox.max._x = radius + pos.X;
            boundingBox.max._y = radius + pos.Y;
        }

        public override TFColliderType GetCType()
        {
            return TFColliderType.Circle;
        }

#if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            UnityEditor.Handles.color = Color.yellow;
            Handles.DrawWireDisc(transform.position + (new Vector3((float)offset.X, (float)offset.Y, 0)), Vector3.forward, ((float)radius));
        }
#endif
    }
}