using UnityEngine;

public interface IHitTaker
{
    void TakeHit(int damage, Vector3 hitPoint, Vector3 velocity, float mass);
}
