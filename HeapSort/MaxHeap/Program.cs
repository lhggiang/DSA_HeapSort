using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; //xem i là chỉ số của phần tử lớn nhất
        int left = 2 * i + 1; //nút con bên trái
        int right = 2 * i + 2; //nút con bên phải
        if (left < n && arr[left] > arr[largest])
            //nếu left bé hơn n phần tử và giá trị ở left > giá trị ở largest
            largest = left;
        if (right < n && arr[right] > arr[largest])
            //nếu right bé hơn n phần tử và giá trị ở right > giá trị ở largest
            largest = right;
        if (largest != i) //nếu largest != i thì có phần tử lớn hơn phần tử ở chỉ số largest
        {
            //đổi vị trí
            int tmp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = tmp;
            //Heapify kiểm tra các nút trung gian
            Heapify(arr, n, largest);
        }
    }
    public static void HeapSort(int[] arr, int n)
    {
        //xây dựng max heap, từ 0 -> n/2-1 là nút khác nút lá
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
        for (int i = n - 1; i >= 0; i--)
        {
            int tmp = arr[i];
            arr[i] = arr[0];
            arr[0] = tmp;
            Heapify(arr, i, 0);
        }
    }
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.UTF8;
        Random rd = new Random();
        int n = 20;
        int[] arr = new int[20];
        for (int i = 0; i < n; i++)
        {
            arr[i] = rd.Next(100);
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\n------------------");
        HeapSort(arr, n);
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
