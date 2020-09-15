using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp0915
{
    class AccountManager
    {
        BankAccount[] accountArr = new BankAccount[10];
        string[] accNum = new string[10];
        string[] accName = new string[10];
        
        int cnt = 0;
        public void PrintMenu()
        {
            Console.WriteLine("\n---Menu-----------");
            Console.WriteLine("1. 계좌 개설");
            Console.WriteLine("2. 입금");
            Console.WriteLine("3. 출금");
            Console.WriteLine("4. 잔액 조회");
            Console.WriteLine("5. 프로그램 종료");
        }

        public void MakeAccount() //1.계좌개설
        {
            Console.Write("계좌번호 : ");
            accNum[cnt] = Console.ReadLine();
            Console.WriteLine("예금주명 : ");
            accName[cnt] = Console.ReadLine();

            accountArr[cnt] = new BankAccount(accNum[cnt],accName[cnt]);
            cnt++;
        }
        private bool CheckAcc() //계좌 개설 확인
        {
            string chName = Console.ReadLine();
            
            int chCnt=0;
            while (true)
            {
                Console.WriteLine("이름을 입력하세요 : ");
                if (accName[chCnt] == chName)
                {
                    Console.Write("계좌 번호를 입력하세요 : ");
                    if (accNum[chCnt] == Console.ReadLine())
                    {
                        cnt = chCnt;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("계좌 번호를 잘못입력했습니다.");
                    }
                }
                else { chCnt++; }
                if(chCnt == 9)
                {
                    Console.WriteLine("해당 이름으로 개설된 계좌가 없습니다.");
                    return false;
                }
            }
        }
        /*private bool CheckAcc() //계좌 개설 확인
        {
            if (accountArr[cnt-1] == null)
            {
                Console.WriteLine("계좌개설을 먼저 해주십시오.");
                return false;
            }
            else
                return true;
        }*/

        public void Deposit() //2.입금
        {
            if (!CheckAcc()) return;

            Console.WriteLine("입금하실 금액은?:");
            int money = int.Parse(Console.ReadLine());
            accountArr[cnt].InputMoney(money);
        }
        public void Withdrawal()
        {
            if (!CheckAcc()) return;
            Console.WriteLine("출금하실 금액은?:");
            int money = int.Parse(Console.ReadLine());
            accountArr[cnt].OutputMoney(money);
        }
        public void CheckAccount()
        {
            if (!CheckAcc()) return;
            accountArr[cnt].PrintAccInfo();

        }
        

    }
    class AccountProgram
    {
        
        static void Main()
        {
            AccountManager manager = new AccountManager();
            int choice;
            while (true)
            {                   
                Console.WriteLine("\n"+manager.ToString());
                manager.PrintMenu();
                Console.WriteLine("선택:");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        manager.MakeAccount(); break;
                    case 2:
                        manager.Deposit(); break;
                    case 3:
                        manager.Withdrawal(); break;
                    case 4:
                        manager.CheckAccount(); break; //break >> switch만 나감
                    case 5:return; //return >> 함수 나감
                    default:
                        Console.WriteLine("다시 선택하세요");break;
                }
            }
        }
    }
}
