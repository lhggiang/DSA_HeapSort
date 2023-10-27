using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    // Hàm HeapifyMin được sử dụng để biến mảng thành min heap
    public static void HeapifyMin(int[] arr, int n, int i)
    {
        int smallest = i; // Khởi tạo biến smallest để lưu trữ chỉ số của nút hiện tại, mặc định là i
        int left = 2 * i + 1; // Tính chỉ số của nút con bên trái
        int right = 2 * i + 2; // Tính chỉ số của nút con bên phải

        // Kiểm tra xem nút con bên trái tồn tại và có giá trị nhỏ hơn nút hiện tại
        if (left < n && arr[left] < arr[smallest])
            smallest = left;

        // Kiểm tra xem nút con bên phải tồn tại và có giá trị nhỏ hơn nút hiện tại hoặc nút con bên trái
        if (right < n && arr[right] < arr[smallest])
            smallest = right;

        // Nếu smallest đã thay đổi (khác i), thì hoán đổi giá trị của nút hiện tại và nút có giá trị nhỏ nhất
        if (smallest != i)
        {
            int tmp = arr[i];
            arr[i] = arr[smallest];
            arr[smallest] = tmp;

            // Gọi đệ quy HeapifyMin trên nút con bị ảnh hưởng (smallest)
            HeapifyMin(arr, n, smallest);
        }
    }

    // Hàm MinHeap xây dựng một min heap từ mảng
    public static void MinHeap(int[] arr)
    {
        int n = arr.Length;

        // Bắt đầu từ nút cha cuối cùng và thụt vào bên trái để xây dựng min heap
        for (int i = (n / 2) - 1; i >= 0; i--)
        {
            HeapifyMin(arr, n, i);
        }
    }

    // Hàm HeapSortMin sắp xếp mảng theo thứ tự tăng dần bằng cách sử dụng min heap
    public static void HeapSortMin(int[] arr)
    {
        MinHeap(arr);

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            // Hoán đổi giá trị của nút đỉnh (nút có giá trị nhỏ nhất) và nút cuối cùng của heap
            int tmp = arr[0];
            arr[0] = arr[i];
            arr[i] = tmp;

            // Gọi HeapifyMin trên phần còn lại của heap để duy trì tính chất min heap
            HeapifyMin(arr, i, 0);
        }
    }

    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.UTF8;
        Random rd = new Random();
        int n = 20;
        int[] arr = new int[20];

        // Khởi tạo mảng với các giá trị ngẫu nhiên
        for (int i = 0; i < n; i++)
        {
            arr[i] = rd.Next(100);
        }

        // In ra mảng ban đầu
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\n------------------");

        // Sắp xếp mảng theo thứ tự tăng dần bằng HeapSortMin
        HeapSortMin(arr);

        // In ra mảng sau khi sắp xếp
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
