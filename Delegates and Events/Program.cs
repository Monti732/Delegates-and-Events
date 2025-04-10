namespace Delegates_and_Events;

class Program {
  static void Main() {
    ShowInitialMenu();

    var basicMatrixOperationHendler = new BasicMatrixOperationHandler();
    var singleMatrixOperationHendler = new SingleMatrixOperationHandler();
    var matrixManegementHendler = new MatrixManagementHandler();
    basicMatrixOperationHendler.SetNextHandler(singleMatrixOperationHendler);
    singleMatrixOperationHendler.SetNextHandler(matrixManegementHendler);
    matrixManegementHendler.SetNextHandler(matrixManegementHendler);
    Console.Clear();
    var menu = new Menu(Data.MainMenuItems);
    menu.OnItemSelected += choice => { basicMatrixOperationHendler.HandleOperation(choice, ref Data.matrixA, ref Data.matrixB); };
    while (true) {
      Console.Clear();
      menu.Show();
    }
  }

  static void ShowInitialMenu() {
    Console.WriteLine("WELCOME TO GIGA MATRIX CALCULATOR 2.0\n\nEnter size of the matrix: ");
    int size = int.Parse(Console.ReadLine());
    Console.WriteLine("\nHow would you like to create a Matrices?\n");
    var initMenu = new Menu(Data.InitMenuItems);
    initMenu.OnItemSelected += choice => {
      Data.matrixA = new SquareMatrix(size, choice);
      Data.matrixB = new SquareMatrix(size, choice);
    };
    initMenu.Show();
  }
}