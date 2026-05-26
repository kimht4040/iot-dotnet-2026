namespace Prac06Arrange
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //클래스
            Person p1 = new Person();
            p1.name = "홍길동";
            p1.walk();

        }

    }
    class Person 
    {
        public string name { get; set; }// 속성
        public int age;// 멤버변수(필드)
        public void walk()
        {
            Console.WriteLine($"[name: {name}, age: {age}] is walking");
        }
    
    }
    // 인터페이스 - 추상클래스와 유사
    public interface IMovable
    {
        void Move();

    }
    class Car : IMovable
    {
        // 인터페이스를 가져다 쓰면 반드시 인터페이스에 있는 메서드 정의를 구현해야함 
        public void Move()
        {

            Console.WriteLine("The car is moving");
        }
    }
}
