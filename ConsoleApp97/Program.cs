using System;

namespace ConsoleApp1 {

 public class Stack <T> where T : new() { 
                                  //у типа данных стека должен быть конструктор по умолчанию
  T [] stck; // массив, содержащий стек
  int tos; // индекс вершины стека
  public Stack (int size) {
   stck = new T [size]; // распределить память для стека
   tos = 0;
  }
  public int Push (T ch) { // Поместить элементы в стек
   if (tos == stck.Length) { //стек заполнен
    return -1;
   }
   stck [tos] = ch;
   tos++;
   return tos;
  }
  public T Pop () { // Извлечь элемент из стека
   if (tos == 0) { //стек пуст
    return default (T);
   }
   tos--;
   return stck [tos];
  }
  public bool IsFull () { // Возвратить значение true, если стек заполнен
   return tos == stck.Length;
  }
  public bool IsEmpty () { // Возвратить значение true, если стек пуст
   return tos == 0;
  }
  public int Capacity () { // Возвратить общую емкость стека
   return stck.Length;
  }
  public int GetNum () { // Возвратить количество объектов, находящихся в данный момент в стеке
   return tos;
  }
 }

 class Program {
  static void Main (string[] args) {
   const int Stack1Size = 10;
   Stack <int> stk1 = new Stack <int> (Stack1Size);
   for (int i = 0; !stk1.IsFull (); i++) stk1.Push (i+1);
   if (stk1.IsFull ()) Console.WriteLine ("Стек stk1 заполнен.");
   // Вывести содержимое стека stk1.
   Console.Write ("Содержимое стека stk1: ");
   while (!stk1.IsEmpty ()) {
    int i = stk1.Pop ();
    Console.Write ("{0} ", i);
   }
   Console.WriteLine ();
   if (stk1.IsEmpty ()) Console.WriteLine ("Стек stk1 пуст.\n");
   // Поместить дополнительные символы в стек stk1.
   Console.WriteLine ("Вновь поместить элементы в стек stk1.");
   for (int i = 0; !stk1.IsFull (); i++) stk1.Push (Stack1Size - i );
   Console.WriteLine ("А теперь извлечь символы из стека stk1 " +
    "и поместить их в стек stk2, добавив дробную часть");
   Stack <double> stk2 = new Stack <double> (Stack1Size);
   while (!stk1.IsEmpty ()) {
    int i = stk1.Pop ();
    stk2.Push ((double)i + 0.5);
   }
   Console.Write ("Содержимое стека stk2: ");
   while (!stk2.IsEmpty ()) {
    double d = stk2.Pop ();
    Console.Write ("{0:F1} ", d);
   }
   Console.WriteLine ();
   Console.WriteLine ("Емкость стека stk2: " + stk2.Capacity ());
   Console.WriteLine ("Количество объектов в стеке stk2: " + stk2.GetNum ());

   Console.ReadKey ();
  }
 }
}