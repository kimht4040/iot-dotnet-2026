using System.Collections;

namespace prac04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[5];
            array1[0] = 1;
            array1[1] = 2;
            array1[2] = 3;
            array1[3] = 4;
            array1[4] = 5;

            Console.WriteLine(array1);


            for (int i = 0; i < array1.Length; i++)
            {

                Console.WriteLine(array1[i] + " ");
            }

            Console.WriteLine();
            // foreach 사용
            foreach (var item in array1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // 컬렉션
            ArrayList al1 = new ArrayList();
            al1.Add(1);
            al1.Add("hello");
            al1.Add(3.14);
            al1.Add(true);
            // 파이썬 처럼 타입 상관없이 입력 가능함

            foreach (var item in al1)
            {
                Console.WriteLine(item);

            }
            al1.Remove("hello");
            foreach (var item in al1)
            {
                Console.WriteLine(item);
            }


            Hashtable ht1 = new Hashtable();
            ht1["apple"]= "사과";
            ht1["banana"] = "바나나";
            ht1["orange"] = "오렌지";

            Console.WriteLine(ht1["apple"]);


        }
    }
}

