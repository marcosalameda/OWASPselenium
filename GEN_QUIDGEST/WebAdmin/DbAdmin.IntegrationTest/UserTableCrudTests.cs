using CSGenio.business;
using NUnit.Framework;
using System;

namespace DbAdmin.IntegrationTest
{
    public class UserTableCrudTests : DatabaseTransactionFixture
    {
        [Test]
        public void InsertUser() {

            var codpsw = InsertTestUser();

            Assert.AreEqual(0, emptyKey(codpsw));
        }

        private string InsertTestUser()
        {
            CSGenioApsw newUser = new CSGenioApsw(_user);
            newUser.ValNome = "IntegrationTester";
            newUser.insert(sp);
            return newUser.ValCodpsw;
        }

        [Test]
        public void ReadUser()
        {
            //Arrange
            var codpsw = InsertTestUser();
            //Act
            CSGenioApsw returnedUser = CSGenioApsw.search(sp, codpsw, _user);
            //Assert
            Assert.AreEqual(codpsw, returnedUser.ValCodpsw);
            Assert.AreEqual("IntegrationTester", returnedUser.ValNome);
        }

        [Test]
        public void EditUser()
        {
            //Arrange
            var codpsw = InsertTestUser();
            CSGenioApsw returnedUser = CSGenioApsw.search(sp, codpsw, _user);
            
            //Act
            returnedUser.ValNome = "IntegrationTester2";
            returnedUser.update(sp);

            //Assert
            Assert.AreEqual(codpsw, returnedUser.ValCodpsw);
            Assert.AreEqual("IntegrationTester2", returnedUser.ValNome);
        }


        [Test]
        public void DeleteUser()
        {
            //Arrange
            var codpsw = InsertTestUser();
            CSGenioApsw existingUser = CSGenioApsw.search(sp, codpsw, _user);

            //Act
            existingUser.delete(sp);

            //Assert
            CSGenioApsw searchedUser = CSGenioApsw.search(sp, codpsw, _user);
            Assert.IsNull(searchedUser);
        }

        public static int emptyKey(object characters)
        {
            if (characters == null || characters.Equals("") || characters.Equals(Guid.Empty.ToString()) || characters.Equals(Guid.Empty.ToString("B")) || characters.Equals("0"))
                return 1;
            else
                return 0;
        }

    }
}
