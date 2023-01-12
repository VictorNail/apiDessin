using Newtonsoft.Json;
using apiDessin;
using apiDessin.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TestApiDessin
{
    [TestClass]
    public class TestDessin
    {
        [TestMethod]
        
         public void TestIdDessin()
        {
            Dessin testDessin= new Dessin();
            testDessin._id = 100;
            Assert.AreEqual(testDessin._id, 100);
        }
    }
}
