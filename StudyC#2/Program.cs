namespace StudyC_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerScore = 80;

            if (playerScore >= 70)
            {
                Console.WriteLine("플레이어의 점수는 70점 이상입니다. 합격입니다!");
            }
            Console.WriteLine("프로그램이 종료됩니다.");



            Console.Write("번호를입력하세요 : ");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("짝수입니다");
            }
            else
            {
                Console.WriteLine("홀수입니다.");
            }


            // 2) 등급 출력
            int playeraScore = 100;
            string playerRank = "";

            switch (playeraScore / 10)
            {
                case 10:
                case 9:
                    playerRank = "Diamond";
                    break;
                case 8:
                    playerRank = "platinum";
                    break;
                case 7:
                    playerRank = "Gold";
                    break;
                case 6:
                    playerRank = "Silver";
                    break;
                default:
                    playerRank = "Bronze";
                    break;

            }
            Console.WriteLine(playerRank);



            //3) 로그인 프로그램

            string id = "id";
            string password = "password";

            Console.Write("아이디를 입력하세요");
            string inputid = Console.ReadLine();
            Console.Write("비밀번호를 입력하세요 : ");
            string inputPassword = Console.ReadLine();
            if (id == inputid && password == inputPassword)
            {
                Console.WriteLine("로그인 성공");
            }
            else
            {
                Console.WriteLine("로그인 실패");
            }

            // 4) 알파벳 판별 프로그램
            Console.Write("문자를 입력하세요 :");
            char input = Console.ReadLine()[0];

            if ((input >= 'a' && input <= 'z') || (input >= 'A' && input <= 'Z'))
            {
                Console.WriteLine("맞음");
            }

        }
    }
}