using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
namespace XpoCriteriaFromLambda
{
    public class Tests
    {
        IDataLayer dl;
        [SetUp]
        public void Setup()
        {
            string conn = DevExpress.Xpo.DB.InMemoryDataStore.GetConnectionStringInMemory(true);
            dl = XpoDefault.GetDataLayer(conn, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (Session session = new Session(dl))
            {
                System.Reflection.Assembly[] assemblies =
                        new System.Reflection.Assembly[] {
                                   typeof(Customer).Assembly
                   };
                session.UpdateSchema(assemblies);
                session.CreateObjectTypeRecords(assemblies);
            }
        }

        [Test]
        public void Test1()
        {
           
            var Criteria1 = CriteriaOperator.FromLambda<Customer>(c => c.Name == "Joche");
            Debug.WriteLine(Criteria1.ToString());

            UnitOfWork unitOfWork = new UnitOfWork(dl);
            Product product = new Product(unitOfWork);

            product.Code = "001";
            product.Name = "Universal subscription";

            unitOfWork.CommitChanges();

            var Criteria2 = CriteriaOperator.FromLambda<InvoiceDetail>(i => i.Product == product);
            Debug.WriteLine(Criteria2.ToString());


            Assert.Pass();
        }
    }
}