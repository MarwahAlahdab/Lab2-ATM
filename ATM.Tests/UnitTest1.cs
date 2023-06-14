using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel;
using System.Reflection;

namespace ATM.Tests;

public class UnitTest1
{
    [Fact]
    public void ViewBalanceTests()
    {
        //Arrange
        decimal expected = Program.Balance;
        //Act
        decimal result = Program.ViewBalance();
        //Assert
        Assert.Equal(result, expected);
    }


    [Theory]
    [InlineData(50, 50)]
    [InlineData(20, 80)]
    public void Withdraw_SubtractAmountFromBalance(decimal amount, decimal expected)
    {
        Program.Balance = 100;

        decimal result = Program.Withdraw(amount);

        Assert.Equal(expected, result);
    }




    [Fact]
    public void Withdraw_NotAllowNegativeAmount()
    {
        Program.Balance = 100;
        decimal amount = -50;

        decimal result = Program.Withdraw(amount);

        Assert.Equal(100, result);
    }



    [Fact]
    public void Withdraw_NotWithdrarHigherThanBalance() // if amount higher than balance
    {
        Program.Balance = 100;

        decimal result = Program.Withdraw(200);

        Assert.Equal(100, result);
    }






    [Theory]
    [InlineData(50, 150)]
    [InlineData(100, 200)]
    public void Deposit_AddAmountToBalance(decimal amount, decimal expected)
    {
        Program.Balance = 100;

        decimal result = Program.Deposit(amount);

        Assert.Equal(expected, result);
    }


    [Fact]
    public void Deposit_NotAllowNegativeAmount()
    {
        Program.Balance = 100;
        decimal amount = -50;

        decimal result = Program.Deposit(amount);

        Assert.Equal(100, result);
    }

}


