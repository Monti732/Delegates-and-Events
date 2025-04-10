namespace Delegates_and_Events;

public class SingleMatrixOperationHandler : MatrixOperationHandler {
  private delegate SquareMatrix DiagonalizeMatrixDelegate(SquareMatrix matrix);

  public override void HandleOperation(int operationChoice, ref SquareMatrix matrixA, ref SquareMatrix matrixB) {
    switch (operationChoice) {
    case 3: 
      SquareMatrix transposed = matrixA.Transpose();
      Console.WriteLine("Transposed Matrix:");
      Console.WriteLine(transposed);
      break;
    case 4: 
      double trace = matrixA.FindTrace();
      Console.WriteLine($"Matrix Trace: {trace}");
      break;
    case 5: 
      try {
        double det = matrixA.Determinant();
        Console.WriteLine($"Matrix Determinant: {det}");
      }
      catch (MatrixException ex) {
        Console.WriteLine($"Error: {ex.Message}");
      }

      break;
    case 6: 
      try {
        SquareMatrix inverse = matrixA.Inverse();
        Console.WriteLine("Inverse Matrix:");
        Console.WriteLine(inverse);
      }
      catch (MatrixException ex) {
        Console.WriteLine($"Error: {ex.Message}");
      }

      break;
    case 7:
      DiagonalizeMatrixDelegate diagonalizeMatrix = delegate(SquareMatrix matrix) {
        SquareMatrix diagonal = (SquareMatrix)matrix.Clone();
        for (int row = 0; row < diagonal.Size; ++row) {
          for (int col = 0; col < diagonal.Size; ++col) {
            if (row != col) {
              diagonal.Matrix[row, col] = 0;
            }
          }
        }

        return diagonal;
      };

      SquareMatrix diagonalMatrix = diagonalizeMatrix(matrixA);
      Console.WriteLine("Diagonal Form: ");
      Console.WriteLine(diagonalMatrix);
      break;
    case 8:
      string comparison = matrixA.CompareTo(matrixB) switch {  // .NET 9.0 is something
        > 0 => "Matrix A > Matrix B",                          // switch statement takes the result of CompareTo
        < 0 => "Matrix A < Matrix B",                          // and on base of result(true, false, other)
        _ => "Matrix A = Matrix B"                             // save the concrete string to variable. Crazy.
      };                                                       // and also it's not implicit type casting, what's even more crazy
      Console.WriteLine(comparison);
      break;
    default:
      if (_nextHandler != null)
        _nextHandler.HandleOperation(operationChoice, ref matrixA, ref matrixB);
      break;
    }
  }
}