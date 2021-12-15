using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap2
{
    internal class Program

    {    
        static void Main(string[] args)

        {
            Console.WriteLine("Day so sap xep gom bao nhieu so :");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {  int d = i+1;
                Console.WriteLine("Nhap so thu " + d );
                arr[i] = int.Parse(Console.ReadLine());
            }

                       
            for (int i =0 ; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        int hoandoi = arr[i];
                        arr[i] = arr[j];
                        arr[j] = hoandoi;
                    }
                }
            }
                
        
            Console.Write("Thu tu giam dan cua mang tren la :" );
            for (int i = 0; i < n; i++)
            {
                Console.Write( arr[i] + " ");
            }

            Console.WriteLine(" ");

            for (int i =0 ; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        int hoandoi = arr[i];
                        arr[i] = arr[j];
                        arr[j] = hoandoi;
                    }
                }
            }
            
            Console.Write("Thu tu tang dan cua mang tren la :" );
            for (int i = 0; i < n; i++)
            {
                Console.Write( arr[i] + " ");
            }
            Console.ReadLine();
        }
    }       
}

