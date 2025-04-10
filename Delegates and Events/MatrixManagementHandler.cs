namespace Delegates_and_Events;

public class MatrixManagementHandler : MatrixOperationHandler {
  public override void HandleOperation(int operationChoice, ref SquareMatrix matrixA, ref SquareMatrix matrixB) {
    switch (operationChoice) {
    case 8:
      matrixA = CreateMatrix();
      break;
    case 9:
      matrixB = CreateMatrix();
      break;
    case 10:
      Console.Clear();
      Console.WriteLine($"Matrix A\n{matrixA}\n");
      Console.WriteLine($"Matrix B\n{matrixB}\n");
      Console.ReadKey();
      break;
    case 11:
      Environment.Exit(0);
      break;
    }
  }

  private static SquareMatrix CreateMatrix() {
    int size;
    int fillByYourself;
    Console.Clear();
    Console.WriteLine("Enter the size of the matrix: ");
    size = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the type of filling: ");
    fillByYourself = Convert.ToInt32(Console.ReadLine());

    return new SquareMatrix(size, fillByYourself);
  }
}