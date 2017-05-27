using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void PersonTest()
        {
            var testPerson= new Person
            {
                Name = "Tobiasz",
                Surename = "Kowalski",
                Address = "Tatra 2/10",
                Telephone = "00202000"
            };
            var person = new Person(testPerson);
            if (person.Name==testPerson.Name && person.Surename==testPerson.Surename && person.Address==testPerson.Address 
                && person.Telephone==testPerson.Telephone)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}