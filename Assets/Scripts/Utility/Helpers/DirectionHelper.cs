using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHelper {
    public static int GetValueFromDirection(EDirection direction)
    {
        return direction == EDirection.Right ? 1 : -1;
    }

    public static Vector2 GetVectorFromDirection(EDirection direction)
    {
        return direction == EDirection.Right ? Vector2.right : Vector2.left;
    }

    public static EDirection GetDirectionFromVectors(Vector3 self, Vector3 other)
    {
        float directionValue = other.x - self.x;
        return directionValue > 0 ? EDirection.Right : EDirection.Left;
    }

    public static int GetDirectionValueFromVectors(Vector3 self, Vector3 other)
    {
        return GetValueFromDirection(GetDirectionFromVectors(self, other));
    }

    public static EDirection GetOppositeDirection(EDirection direction)
    {
        return direction == EDirection.Left ? EDirection.Right : EDirection.Left;
    }
}
