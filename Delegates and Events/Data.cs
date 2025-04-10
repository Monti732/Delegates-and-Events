namespace Delegates_and_Events;

public struct Data {
  public static string[] MainMenuItems = [
    "Add Matrices (A + B)", "Multiply Matrices (A * B)", "Transpose Matrix", "Find Trace of matrix",
    "Find Determinant of matrix", "Find Inverse Matrix", "Convert Matrix to Diagonal form", "Compare Matrices",
    "Create New Matrix A", "Create New Matrix B", "Display both Matrices", "Exit"
  ];

  public static string[] InitMenuItems = ["Automatically", "Manually"];
  public static SquareMatrix matrixA, matrixB;
}