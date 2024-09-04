using UnityEngine;

public static class IGB283Transform {
    public static Matrix3x3 Rotate(float angle) {
		Matrix3x3 matrix = new Matrix3x3();

		matrix.SetRow(0, new IGB283Vector3(Mathf.Cos(angle), -Mathf.Sin(angle), 0.0f));
		matrix.SetRow(1, new IGB283Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0.0f));
		matrix.SetRow(2, new IGB283Vector3(0.0f, 0.0f, 1.0f));

		return matrix;
	}

    public static Matrix3x3 Translate(IGB283Vector3 offset) {
        Matrix3x3 matrix = new Matrix3x3();

        matrix.SetRow(0, new IGB283Vector3(1.0f, 0.0f, offset.x));
        matrix.SetRow(1, new IGB283Vector3(0.0f, 1.0f, offset.y));
        matrix.SetRow(2, new IGB283Vector3(0.0f, 0.0f, 1.0f));

        return matrix;
    }

    public static Matrix3x3 Scale(IGB283Vector3 scale) {
        Matrix3x3 matrix = new Matrix3x3();

        matrix.SetRow(0, new IGB283Vector3(scale.x, 0.0f, 0.0f));
        matrix.SetRow(1, new IGB283Vector3(0.0f, scale.y, 0.0f));
        matrix.SetRow(2, new IGB283Vector3(0.0f, 0.0f, 1.0f));

        return matrix;
    }
}