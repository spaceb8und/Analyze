using System;

namespace ConsoleApp1 {
 class Point3D {
  private double x, y, z; //Трёхмерные координаты
  public Point3D () { x = y = z = 0; }
  public Point3D (double x, double y, double z = 0) { this.x = x; this.y = y; this.z = z; }
  public static Point3D operator + (Point3D op1, Point3D op2) { //Перегрузить бинарный оператор +
   Point3D result = new Point3D ();
   result.x = op1.x + op2.x;
   result.y = op1.y + op2.y;
   result.z = op1.z + op2.z;
   return result;
  }
  public static Point3D operator + (Point3D op1, double op2) { 
   //Перегрузить бинарный + для сложения с числом (вторым операндом)
   Point3D result = new Point3D ();
   result.x = op1.x + op2;
   result.y = op1.y + op2;
   result.z = op1.z + op2;
   return result;
  }
  public static Point3D operator + (double op1, Point3D op2) {
   //Перегрузить бинарный + для сложения с числом, если число является первым операндом
   Point3D result = new Point3D ();
   result.x = op2.x + op1;
   result.y = op2.y + op1;
   result.z = op2.z + op1;
   return result;
  }
  public static Point3D operator - (Point3D op) { // Перегрузить унарный оператор -
   Point3D result = new Point3D ();
   result.x = -op.x;
   result.y = -op.y;
   result.z = -op.z;
   return result;
  }
  public static bool operator < (Point3D op1, Point3D op2) { // Оператор сравнения
   return (
    Math.Sqrt (op1.x * op1.x + op1.y * op1.y + op1.z * op1.z) <
    Math.Sqrt (op2.x * op2.x + op2.y * op2.y + op2.z * op2.z) ? true : false );
  }
  public static bool operator > (Point3D op1, Point3D op2) { // "Меньше" и "больше" работают только вместе
   return (
    Math.Sqrt (op1.x * op1.x + op1.y * op1.y + op1.z * op1.z) >
    Math.Sqrt (op2.x * op2.x + op2.y * op2.y + op2.z * op2.z) ? true : false );
  }
  public static bool operator true (Point3D op) { 
   // Перегрузка true, истинна, если хотя бы 1 координата не равна 0
   return op.x != 0 || op.y != 0 || op.z != 0 ? true : false;
  }
  public static bool operator false (Point3D op) { // true и false работают только вместе
   return op.x == 0 && op.y == 0 && op.z == 0 ? true : false; //все координаты равны 0
  }
  public static bool operator | (Point3D op1, Point3D op2) { 
   // Перегрузка логического "или", истинна, если хотя бы одна коррдината ненулевая
   return op1.x * op2.x != 0 || op1.y * op2.y != 0 || op1.z * op2.z != 0 ? true : false;
  }
  public static bool operator & (Point3D op1, Point3D op2) {
   // Перегрузка логического "и", истинна, если все коррдинаты ненулевые
   return op1.x * op2.x != 0 & op1.y * op2.y != 0 & op1.z * op2.z != 0 ? true : false;
  }
  public static bool operator ! (Point3D op) {
   // Перегрузка true, ложна, если хотя бы 1 координата не равна 0
   return op.x != 0 || op.y != 0 || op.z != 0 ? false : true;
  }
  public static implicit operator double (Point3D op1) {
   //Неявное преобразование типа, выполняется автоматически, когда объект используется
   //в выражении вместе со значением целевого типа
   return op1.x * op1.y * op1.z;
  }
  public static explicit operator float (Point3D op1) {
   //Явное преобразование типа
   return (float)op1.x * (float) op1.y * (float) op1.z;
  }

  public override string ToString () {
   // Вернуть координаты в виде строки, перегрузив метод ToString по умолчанию
   return this.x + ", " + this.y + ", " + this.z;
  }
}
internal class Program {
  private static void Main () {
   Point3D a = new Point3D (1, 2, 3);
   Point3D b = new Point3D (1, 1, 1);
   Point3D c = new Point3D ();
   Console.WriteLine ("Координаты точки a: {0}", a.ToString ());
   Console.WriteLine ("Координаты точки b: {0}", b.ToString ());
   Console.WriteLine ("Координаты точки c: {0}", c.ToString ());
   Point3D d = a + b + c; 
   Console.WriteLine ("A + B + C = {0}", d.ToString ());

   d = -a;
   Console.WriteLine ("D = -A = {0}", d.ToString ());
   d += 1; //не нужно отдельно перегружать оператор "+="!
   Console.WriteLine ("D = -A + 1 = {0}", d.ToString ());
   d = 1 + d; //а здесь вызовется второй оператор для сложения с числом
   Console.WriteLine ("D = 1 + D = {0}", d.ToString ());

   bool cond = a < b;
   Console.WriteLine ("A < B = {0}", cond);
   cond = a > b;
   Console.WriteLine ("A > B = {0}", cond);

   if (c) Console.WriteLine ("Точка C истинна");
   else Console.WriteLine ("Точка C ложна");
   if (d) Console.WriteLine ("Точка D истинна");
   else Console.WriteLine ("Точка D ложна");

   if (a & d) Console.WriteLine ("a & d истинно");
   else Console.WriteLine ("a & d ложно");
   if (a | d) Console.WriteLine ("a | d истинно");
   else Console.WriteLine ("a | d ложно");
    //с "укороченными" формами &&, || такие перегрузки работать не будут
   if (!c) Console.WriteLine ("Точка !C истинна");
   else Console.WriteLine ("Точка !C ложна");

   double val  = d * 2 + b; // преобразовать в тип double неявно
   Console.WriteLine ("d * 2 + b = " + val);
   float fval = (float)b * (float)Math.PI; // преобразовать в тип float явно
   Console.WriteLine ("b * PI = " + fval);

   Console.ReadKey ();
  }

 }
}