using UnityEngine;

public class GravityGun : MonoBehaviour
{
    //�������� ������� �������
    public float launchSpeed = 40;

    //������ �� ������, ������� ������������
    Rigidbody _target = null;
    bool _isLocked = false;

    void Update()
    {
        //���� ����� ��� �� ������������� ������
        if (!_isLocked)
        {
            //���� ������ ����� ������ ����
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Q))
            {
                RaycastHit hit;
                //������� ��� ����� ����� ������
                if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit))
                {
                    //���� ��� ����� � ������ � ����������� Rigidbody
                    if (hit.rigidbody != null)
                    {
                        //��������� ������
                        Debug.Log(hit.collider.name);
                        LockOnTarget(hit.rigidbody);
                    }
                }
            }
        }
        else
        {
            //���� ���� ��������������� ������, ���������� ������ � ����� ����� ������ ����
            _target.transform.position = transform.position;
            if (Input.GetKeyDown(KeyCode.R))
            {
                //���� ������ ����� ������ ����, ��������� ������
                ReleaseTarget();
            }
        }

    }

    void LockOnTarget(Rigidbody target)
    {
        //���������� ����� ������ ������������
        _target = target;
        //��������� ������ � �������
        _target.isKinematic = true;
        //���������� ������ � ����� �����
        _target.transform.position = transform.position;
        _isLocked = true;
    }

    void ReleaseTarget()
    {
        //�������� ������ � �������
        _target.isKinematic = false;
        //��������� ������ ������ �� ��������� launchSpeed
        _target.velocity = transform.forward * launchSpeed;
        //�������� ������ �� ������
        _target = null;
        _isLocked = false;
 
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)));
    }
}
