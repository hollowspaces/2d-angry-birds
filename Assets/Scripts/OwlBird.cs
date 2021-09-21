using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{
    public float _explosionForce;
    public float _explosionRad;
    public bool _hasExploded = false;

    public LayerMask LayerToHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(ExplodeWithDelay(1f));
    }

    public void Explode()
    {
        if (State == BirdState.Thrown && !_hasExploded)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _explosionRad, LayerToHit);

            foreach(Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;

                obj.GetComponent<Rigidbody2D>().AddForce(direction * _explosionForce);
            }

            _hasExploded = true;
        }
    }

    public IEnumerator ExplodeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Explode();
        Debug.Log("BOOM!");
    }

    public override void OnTap()
    {
        Explode();
        Debug.Log("BOOM!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _explosionRad);
    }
}
