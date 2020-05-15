using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints;
 
    private int _currentIndex = 1;
    private bool _isFollowing = false;
    private float _speed = 10f;

    public bool flowEnd;

    private void Update()
    {
        if (!_isFollowing)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentIndex].position, _speed * Time.deltaTime);
        if (Vector2.Distance(_waypoints[_currentIndex].position, transform.position) < 0.01f)
        {
            transform.position = _waypoints[_currentIndex].position;
            if (_currentIndex >= _waypoints.Count - 1)
            {
                _isFollowing = false;
                flowEnd = true;
                this.GetComponent<Enemy>().EndDest();   
            }
            else
            {
                _currentIndex++;
            }
        }
    }

    public void StartFollow(List<Transform> waypoints)
    {
        _waypoints = waypoints;
        _isFollowing = true;
    }
}
