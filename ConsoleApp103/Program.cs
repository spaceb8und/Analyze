using System;

namespace ConsoleApp1 {
 public class Array <T> where T : new() { //"Отказоустойчивый" вектор с индексаторами
  T [] a; //Ссылка на базовый массив
  public int Length { get; set; } //Длина массива сделана автосвойством
  public bool ErrFlag { get; private set; }
   //Результат последней операции - автосвойство "только для чтения" извне
  public Array (int size) { //Конструктор
   if (size > 0) {
    a = new T [size];
    Length = size;
   }
   else Length = 0;
  }
  
  public T this [int index] { //Индексатор
   get { //Аксессор get
    if (IndexIsValid (index)) {
     ErrFlag = false;
     return a [index];
    }
    else {
     ErrFlag = true;
     return default (T);
    }
   }
   set { //Аксессор set; получает неявный параметр value!
    if (IndexIsValid (index)) {
     a [index] = value;
     ErrFlag = false;
    }
    else ErrFlag = true;
   }
  }
  public T this [double index] { //Ещё один индексатор, для индекса типа double
   get {
    int intIndex = (int) Math.Round (index);
    return this [intIndex];
   }
   set {
    int intIndex = (int) Math.Round (index);
    this [intIndex] = value;
   }
  }
  public bool this [bool index] { 
   //Индексатор без set, только для чтения, возвращает состояние this.ErrFlag
   get {
    return ErrFlag;
   }
   //Аксессор set отсутствует
  }
  private bool IndexIsValid (int index) {
   if (Length < 1) return false;
   return (index >= 0 & index < Length ? true : false);
  }
 }

 public class Array2D <T> where T : new() { //"Отказоустойчивая" матрица с индексаторами
  T [,] a; //Ссылка на базовый массив
  int rows, cols; //Количество строк и столбцов, приватные
  int len; //Длина массива, на этот раз приватная
  public int Length { //Получим её свойством "только для чтения"
   get { return len; }
  }
  bool err; //Результат последней операции, приватный
  public bool ErrFlag { //Получим его свойством "только для чтения"
   get { return err; }
  }
  public Array2D (int r, int c) {
   if (r > 0 & c > 0) {
    rows = r; cols = c;
    a = new T [rows, cols];
    len = rows * cols;
   }
   else len = 0;
  }
  public void Print (String hdr = "") { //Вывод в консоль
   Console.WriteLine ();
   Console.WriteLine (hdr);
   for (int i = 0; i < rows; i++) {
    for (int j = 0; j < cols; j++)
     Console.Write ("{0} ", a [i, j]);
    Console.WriteLine ();
   }
  }
  public T this [int row, int col] { //Двумерный индексатор
   get {
    if (IndexIsValid (row, col)) {
     err = false;
     return a [row, col];
    }
    else {
     err = true;
     return default (T);
    }
   }
   set {
    if (IndexIsValid (row, col)) {
     a [row, col] = value;
     err = false;
    }
    else err = true;
   }
  }
  public int Rows { //свойство Rows для изменения приватного количества строк
   get { return rows; }
   set { if (value > -1 & value < rows) rows = value; }
  }
  public int Cols { //свойство Rows для изменения приватного количества столбцов
   get { return cols; }
   set { if (value > -1 & value < cols) cols = value; }
  }
  private bool IndexIsValid (int r, int c) {
   if (len < 1) return false;
   return ( r > -1 & r < rows & c > -1 & c < cols ? true : false );
  }
 }

 class Program {
  static void Main (string [] args) {
   Array <int> arr = new Array <int> (5);
   for (int i = 0; i < arr.Length + 1; i++) { //Берём 1 лишний элемент!
    arr [i] = i + 1;
    Console.WriteLine (arr [i] + "  (ErrFlag = "+ arr.ErrFlag + ")");
   }
   Array <double> darr = new Array <double> (5);
   for (double x = 0.1; x < arr.Length ; x += 0.9) { //Берём 1 лишний элемент, 2-й индексатор
    darr [x] = x + 1;
    Console.WriteLine (arr [x] + "  (ErrFlag = " + arr.ErrFlag + ")");
   }
   Console.WriteLine ("arr [true]   = " + arr [true]); //Третий индексатор

   Array2D <int> matr = new Array2D<int> (2, 2);
   for (int i = 0; i < 3; i++) { //Лишняя строка
    Console.WriteLine();
    for (int j = 0; j < 2; j++) {
     matr [i, j] = i + j;
     Console.Write ("{0:D} ({1}) ", matr [i, j], matr.ErrFlag);
    }
   }
   matr.Rows = 2; //Меняем количество строк с помощью свойства
   matr.Print ("Матрица после изменения количества строк");

  Console.ReadKey ();
  }
 }

}