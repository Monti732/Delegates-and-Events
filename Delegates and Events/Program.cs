namespace Delegates_and_Events;

class Program {
  static void Main() {
    var matrix = new SquareMatrix(3,0);
    Console.WriteLine(matrix);
    Console.WriteLine($"\n{matrix.Transpose()}\n");
    Console.WriteLine(matrix.FindTrace());
    Console.WriteLine($"\n{matrix.ToDiagonalForm()}");
  }
}
