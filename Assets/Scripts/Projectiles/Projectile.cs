using UnityEngine;

public class Bullet {
    public Vector3 hitPoint;
    public int hitDamage;

    public Bullet(int damage, Vector3 point) {
        hitDamage = damage;
        hitPoint = point;
    }
}
