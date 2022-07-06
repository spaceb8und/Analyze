using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
 abstract class Shape { //Абстрактный класс "фигура"
  public abstract string GetTypeString (); //Абстрактный метод, должен быть определён у потомков
 }

 class Shape2D : Shape { //Базовый класс - рамка фигуры
  double width, height; //Приватные ширина и высота
  int frac = 2; //Количество знаков в дробной части при выводе
  public Shape2D (double width = 0, double height = 0, int frac = 2) {
   //Конструктор базового класса-"рамки"
   Width = width;
   Height = height;
   this.frac = frac;
  }
  public double Width { // Публичные свойства ширины и высоты двумерного объекта
   get { return width; }
   set { width = value < 0 ? -value : value; }
  }
  public double Height {
   get { return height; }
   set { height = value < 0 ? -value : value; }
  }
  public int Frac { //Публичное свойство "количество знаков в дробной части"
   get { return frac; }
   set { width = frac < 1 ? 0 : ( frac > 14 ? 14 : value ); }
  }
  public double RoundTo (double d) { //Округлить до нужного количества знаков
   return Math.Round (d, Frac);
  }
  public string GetSizeString () { //Строка с габаритами
   return RoundTo (Width) + " x " + RoundTo (Height);
  }
  public override string GetTypeString () { //Реализация абстрактного метода
   return "рамка фигуры";
  }
  public virtual double Area () { //Виртуальный метод "площадь рамки"
   return RoundTo (Width * Height);
  }
 }

 class Triangle : Shape2D { //Производный класс - треугольник
  protected string Style; //Тип треугольника, защищённое свойство
  protected double A, B, C; //Стороны треугольника, защищённые свойства
  public Triangle (double A = 3, double B = 4, double C = 5) {
   if (A + B > C & A + C > B & B + C > A) {
    double [] Temp = new double [] { A , B , C };
    Array.Sort (Temp);
    this.C = Width = Temp [2];
    this.B = Temp [1];
    this.A = Temp [0];
    Height = GetHeight (Temp [1]);
    var Temp2 = new List <double> () { Temp [0] * Temp [0], Temp [1] * Temp [1], Temp [2] * Temp [2] };
    this.Style = Temp2 [2] < Temp2 [0] + Temp2 [1] ?
     (Temp2 [0] == Temp2 [1] ? "равносторонний" : "остроугольный") :
     (Temp2 [2] > Temp2 [0] + Temp2 [1] ? "тупоугольный" : "прямоугольный");
   }
   else {
    this.A = this.B = this.C = Width = Height = 0;
    this.Style = "не существует";
   }
  }
  private double GetHeight (double a) {//высота, опущенная на сторону a (большую из всех)
   double P = ( A + B + C ) / 2;
   return RoundTo (2 * Math.Sqrt (P * ( P - A ) * ( P - B ) * ( P - C )) / A);
  }
  public override double Area () { //Площадь треугольника
   double P = ( A + B + C ) / 2;
   return RoundTo (Math.Sqrt(P * (P - A) * (P - B) * (P - C)));
  }
  public override string GetTypeString () { //Переопределение виртуального метода
   return Style;
  }
 }
 public static class Measures { //Неуниверсальный статический класс с расширениями
  public static double ToRadians (this double angleInDegree) { //Угол в градусах - в радианы
   return ( angleInDegree * Math.PI ) / 180.0;
  }
 }

 sealed class Triangle2С : Triangle {
  //Производный от треугольника - треугольник, заданный двумя сторонами и углом между ними
  //Этот класс наследовать уже нельзя (sealed)
  public Triangle2С (double A, double B, double angleC) : 
   base (A, B, 
    Math.Sqrt(Math.Pow(A,2) + Math.Pow(B,2) - 2*A*B*Math.Cos(Measures.ToRadians(angleC)))) {
   //использует конструктор базового класса, вычислив по теореме косинусов третью сторону
  }
 }

 class Program { //Главный класс, демонстрация
  static void Main (string [] args) {
   Triangle t1 = new Triangle ();
   Console.WriteLine ("Сведения об объекте t1: тип {0}, габариты {1}", 
    t1.GetTypeString (), t1.GetSizeString ());
   Console.WriteLine ("Площадь равна " + t1.Area () + System.Environment.NewLine);

   Triangle t2 = new Triangle (4,4,4);
   Console.WriteLine ("Сведения об объекте t2: тип {0}", t2.GetTypeString ());
   Console.WriteLine ("Габариты равны {0}x{1}", t2.Width, t2.Height);
   Console.WriteLine ("Площадь равна " + t2.Area ());
   Console.WriteLine ();

   Triangle2С t3 = new Triangle2С (4,4,60); //Совпадёт со 2-м, но задан по-другому
   Console.WriteLine ("Сведения об объекте t3: тип {0}, габариты {1}",
    t3.GetTypeString (), t3.GetSizeString ());
   //тип изменился с "равносторонний" на "остроугольный" из-за погрешностей при расчёте C!
   Console.WriteLine ("Площадь равна " + t3.Area ());
   Console.WriteLine ();

   Shape2D [] Shapes = new Shape2D [4]; //Массив объектов базового класса
   Shapes [0] = t1;
   Shapes [1] = t2;
   Shapes [2] = t3;
   Shapes [3] = new Shape2D(3,-4,1); //Свойство Height превратит "-4" в "4"
   foreach (var Shape in Shapes)
    Console.WriteLine ($"Тип объекта = {Shape.GetTypeString()}");
   Console.WriteLine ();

   Console.ReadKey ();
  }
 }

} 