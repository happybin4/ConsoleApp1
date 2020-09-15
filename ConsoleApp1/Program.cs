using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp0915
{
    public class BankAccount
    {
        private static double interest = 0.2;   //이자율
        private string accNum;           //계좌번호
        private string name;             //예금주명
        private int balance = 0;         //잔액       

        #region property
        public string AccNum
        {
            get { return accNum; }
            set { accNum = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public int Balance
        {
            get { return balance; }
        }
        #endregion

        #region ctor
        public BankAccount()
        {
            balance = 10;
        }
        public BankAccount(string accNum, string name)
        {
            this.accNum = accNum;
            this.name = name;
            balance = 10;
        }
        #endregion

        #region method
        //출금
        public string OutputMoney(int amount)
        {
            if(balance < amount)
            {
                string msg = "잔액이 부족합니다";
                return msg;
            }
            
            this.balance -= amount;
            return amount + "원 출금되었습니다 남은 잔액 : "+ balance;
        }

        //예금
        public void InputMoney(int amount)
        {
            this.balance = this.balance + amount + (int)(amount * interest);
        }
        //정보출력
        public void PrintAccInfo()
        {
            Console.WriteLine($"계좌번호 : {this.accNum} 예금주 : {this.name} 잔액 : {this.balance} 이율 : {BankAccount.interest}%");
        }
        //이자율 변경
        public static void SetInterest(double interest)
        {
            BankAccount.interest = interest;

        }
        

        #endregion
    }
    class Program
    {
        static void Main(string[] args)
       {
            AccountProgram manager = new AccountProgram();
            Console.WriteLine(manager.ToString());

            

            BankAccount acc0 = new BankAccount();
            acc0.AccNum = "111-11111";
            acc0.Name = "홍길동";
            Console.WriteLine(acc0.Balance);

            BankAccount acc1 = new BankAccount();
            acc1.AccNum = "222-22222";
            acc1.Name = "류현진";

            BankAccount acc2 = new BankAccount("333-33333", "김개똥");
            acc2.PrintAccInfo();

            BankAccount acc3 = new BankAccount("444-44444", "김샛별");
            acc3.InputMoney(10000);
            Console.WriteLine(acc3.OutputMoney(5000));
        }
    }
}
