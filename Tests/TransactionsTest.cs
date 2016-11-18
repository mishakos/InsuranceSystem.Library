using System;
using InsuranceSystem.Library.Model.Catalogs;
using InsuranceSystem.Library.DataLayer.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceSystem.Library.DataLayer.LinqQueries.Catalogs;

namespace Tests
{
    [TestClass]
    public class TransactionsTest
    {
        [TestMethod]
        public void AddClient()
        {
            int Id = 0;
            AddClientTransaction act = new AddClientTransaction(Id, "ТОВ \"При-Информ\"","12345678", "123456789012");
            act.Execute();
            Clients clients = new Clients();
            Client client = clients.Get(Id);
            Assert.IsNotNull(client);
            Assert.AreEqual("ТОВ \"При-Информ\"", client.Name);
            Assert.IsFalse(client.IsDelete);
            Assert.AreEqual("12345678", client.EDRPOU);
            Assert.AreEqual("123456789012", client.ITN);
            Assert.AreEqual("ТОВ \"При-Информ\"", client.FullName);
        }
    }
}
