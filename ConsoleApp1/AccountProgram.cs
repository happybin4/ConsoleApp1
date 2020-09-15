﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp0915
{
    class AccountManager
    {
        BankAccount account;
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
            string accNum = Console.ReadLine();
            Console.WriteLine("예금주명 : ");
            string accName = Console.ReadLine();

            account = new BankAccount(accNum,accName);
        }
        
        private bool CheckAcc() //계좌 개설 확인
        {
            if (account == null)
            {
                Console.WriteLine("계좌개설을 먼저 해주십시오.");
                return false;
            }
            else
                return true;
        }

        public void Deposit() //2.입금
        {
            if (!CheckAcc()) return;

            Console.WriteLine("입금하실 금액은?:");
            int money = int.Parse(Console.ReadLine());
            account.InputMoney(money);
        }
        public void Withdrawal()
        {
            if (!CheckAcc()) return;
            Console.WriteLine("출금하실 금액은?:");
            int money = int.Parse(Console.ReadLine());
            account.OutputMoney(money);
        }
        public void CheckAccount()
        {
            if (!CheckAcc()) return;
            account.PrintAccInfo();

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
