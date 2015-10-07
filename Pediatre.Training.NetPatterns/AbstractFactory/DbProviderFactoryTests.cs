using System.Configuration;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.AbstractFactory
{
    /// <summary>
    /// Summary description for DbProviderFactoryTests
    /// </summary>
    [TestClass]
    public class DbProviderFactoryTests
    {
        [TestMethod]
        public void DbProviderFactory_With_Sql_ShouldReturnSqlDbCommand()
        {
            // Arrange
            var sut = new MyDbProviderFactory();
            
            // Act
            sut.ExecuteQuery();
            
            // Assert

        }
    }

    public class MyDbProviderFactory
    {
        private readonly DbProviderFactory _factory;

        public MyDbProviderFactory()
        {
            var setting = ConfigurationManager.ConnectionStrings["NorthWind"];
            var providerName = setting.ProviderName;
            _factory = DbProviderFactories.GetFactory(providerName);
        }

        public void ExecuteQuery()
        {
            using (var connection = _factory.CreateConnection())
            {
                var command = _factory.CreateCommand();
                if (command != null)
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from products";
                }
            }
        }
    }
}
