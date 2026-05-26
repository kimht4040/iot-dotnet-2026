// C#은 네임스페이스 내 동작 
// 파이썬에 import로 불러올 수 있는 패키지와 동일
namespace ConsoleApp2
{
    // 모든 것은 객체
    internal class Program
    {
        // 기본 진입점 메서드 - 프로그램이 시작될 때 가장 먼저 실행되는 메서드
        static void Main(string[] args)
        {
            // 빌트인 클래스 콘솔 내의 WriteLLine 메서드로 콘솔에 문자열 출력하라
            Console.WriteLine("Hello, World!");
        }
    }
}
