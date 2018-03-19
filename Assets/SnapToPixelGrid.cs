using UnityEngine;

public class SnapToPixelGrid : MonoBehaviour 
{
	private int pixelsPerUnit = 32;

	/// <summary>
	/// Snap the object to the pixel grid determined by the given pixelsPerUnit.
	/// Using the parent's world position, this moves to the nearest pixel grid location by 
	/// offseting this GameObject by the difference between the parent position and pixel grid.
	/// </summary>
	private void LateUpdate()
	{
		Transform parent = transform.parent;
		Vector3 newLocalPosition = Vector3.zero;

		newLocalPosition.x = (Mathf.Round(parent.position.x * pixelsPerUnit) / pixelsPerUnit) - parent.position.x;
		newLocalPosition.y = (Mathf.Round(parent.position.y * pixelsPerUnit) / pixelsPerUnit) - parent.position.y;
		newLocalPosition.z = (Mathf.Round(parent.position.z * pixelsPerUnit) / pixelsPerUnit) - parent.position.z;

		transform.localPosition = newLocalPosition;
	}
}