using UnityEngine;

public class Projectile {
    public Vector3 hitPoint;
    public int hitDamage;

    public Projectile(int damage, Vector3 point) {
        hitDamage = damage;
        hitPoint = point;
    }
}
