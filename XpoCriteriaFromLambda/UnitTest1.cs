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

            //Invoices that contains an specific product 
            var Criteria3 = CriteriaOperator.FromLambda<Invoice>(i => i.InvoiceDetails.Where(id=>id.Product == product)!=null);
            Debug.WriteLine(Criteria3.ToString());

            //Customers with invoice with a total greater or equal to 1000
            var Criteria4 = CriteriaOperator.FromLambda<Customer>(c => c.Invoices.Where(i => i.Total >=1000).Count()>0);
            Debug.WriteLine(Criteria4.ToString());

            Assert.Pass();
        }
    }
}