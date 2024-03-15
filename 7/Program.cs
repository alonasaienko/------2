/*Варіант 1:
Створіть клас ArrayManipulator, який має методи для роботи з масивами цілих чисел:
Метод GenerateRandomArray(int length, int min, int max), 
який створює та повертає новий масив заданої довжини з випадковими числами в діапазоні від min до max.
Метод FindMax(int[] array), який знаходить та повертає найбільший елемент у масиві.
Метод SortArray(int[] array), який сортує масив у зростаючому порядку.

Після створення класу запустіть програму, яка створює масив, 
знаходить найбільший елемент та сортує масив. 
Виведіть початковий масив, знайдений максимум та відсортований масив на консоль.*/

using System;

static class ArrayManipulator
{
    static public int[] GenerateRandomArray(int length, int min, int max)
    {
        int[] array = GenerateRandomArray(length, min, max);
        
        return array;
    }
    static public int FindMax(int[] array)
    {
        int max = array.Max();
        return max;
    }
    /*static public void Sort(int[] array)
    {
        int[] sortarray = new int[array.Length];
        for (int i = 0; i<array.Length; i++)
        {
            sortarray = array.Where(array[i] > array[i+1]);
        }
    }*/
}

class Program
{
    static void Main()
    {
        int[] array = ArrayManipulator.GenerateRandomArray(10, 5, 10);
        Console.WriteLine(ArrayManipulator.FindMax(array));
    }
}
