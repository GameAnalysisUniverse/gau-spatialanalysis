﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class HeapSort<T> : ISorting<T> where T :IComparable
    {
        public static void Sort(T[] A)
        {
            Console.WriteLine("Performing Heap-Sort");
            /*
             * Erstelle den Heap in Array A. Für einen Heap gilt, dass das größte element an erster Stelle im array liegt
             */
            Console.WriteLine("Input Array: " + string.Join(".", A));
            ToHeap(A, A.Length - 1);
            Console.WriteLine("After Heap: " + string.Join(".", A));

            /*
             * Laufe von links nach rechts über Array A mit Heapeigenschaft und vertausche
             * zuerst das Element an Stelle i mit dem Ersten. Anschleißend wende sink an.
             * Effekt:
             * 
             */
            for (int i = A.Length - 1; i >= 0; --i)
            {
                /*
                 * Setze das größte Element welches im Max-Heap an der Wurzel liegt(erstes
                 * Element im Array A an die passende Stelle hinten im Array(am Anfang ans Ende,
                 * dann vorletzte Position usw)
                 */
                Swap(A, 0, i);
                Sink(A, i, 0);
            }
        }

        /**
         * Erstelle einen Heap des Array A mit Länge n (Anzahl der Knoten)
         * 
         * @param A
         * @param n
         */
        static void ToHeap(T[] A, int n)
        {
            Console.WriteLine("Build Heap");
            int mid = n / 2;
            // Gehe über alle inneren Knoten-Indizes
            // Bsp.: n=7 -> von i = {3,2,1,0}
            for (int i = mid; i >= 0; --i)
                Sink(A, n, i);

            Console.WriteLine("Building Heap finished");
        }

        /*
         * Sink bewirkt einen Knoten-Swap innerhalb einer Heap-Baumstruktur wobei Stelle i vertauscht wird, um die
         * geforderte Heap-Eigenschaft (wieder-)herzustellen. N ist hierbei die anzahl der elemente im heap
         * Der Knoten wird solange in die richtige Richtung im Baum abgesenkt bis die Heapeigenschaft gilt
         */
        static void Sink(T[] A, int n, int i)
        {
            Console.WriteLine("Perform sink: (" + n + "," + i + ") on " + A.ToString());
            int mid = n / 2; // Grenze aller inneren Knoten-Indizes
                             // Solange i kleiner n halbe
            while (i < mid)
            {
                int j = 2 * i;
                // Wenn der Nachfolger von j größer ist...
                if ((j < n) && Greater(A[j+1], A[j]))
                    j++; // ...erhöhe j


                // Wenn j größer als i ist
                if (Greater(A[j], A[i]))
                {
                    // Vertausche die beiden und setze i = j
                    Swap(A, j, i);
                    i = j;
                }
                else
                {
                    // Sonst setzte i = n
                    i = n;
                }
            }
            Console.WriteLine("End sink");
        }
    }
}
