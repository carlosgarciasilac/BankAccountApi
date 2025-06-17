using Api.Dtos;
using Domain.Models;

namespace ApiUnitTests;

[TestClass]
public class DtoTests {

    [TestMethod]
    public void TestConvertion() {

        // Arrange
        var bankAccount = new BankAccount
        {
            Id = 1,
            AccountNumber = "123456789",
            AccountBalance = 1000.00m,
            AccountHolder = "John Doe",
            DepositHistory = string.Empty,
            WithdrawalHistory = string.Empty,
        };

        // Act
        var result = BankAccountDto.FromBankAccount.Compile().Invoke(bankAccount);

        Assert.IsTrue(result is BankAccountDto);
        Assert.AreEqual(bankAccount.Id, result.Id);
        Assert.AreEqual(bankAccount.AccountNumber, result.AccountNumber);
        Assert.AreEqual(bankAccount.AccountBalance, result.AccountBalance);
    }

}
