using DevExpress.Xpo;
using System;
using System.Linq;

namespace XpoCriteriaFromLambda
{
    public class Invoice : DevExpress.Xpo.XPObject
    {
        public Invoice(Session session) : base(session)
        {

        }


        Customer customer;
        decimal total;
        string date;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }


        public decimal Total
        {
            get => total;
            set => SetPropertyValue(nameof(Total), ref total, value);
        }

        [Association("Customer-Invoices")]
        public Customer Customer
        {
            get => customer;
            set => SetPropertyValue(nameof(Customer), ref customer, value);
        }

        [Association("Invoice-InvoiceDetails")]
        public XPCollection<InvoiceDetail> InvoiceDetails
        {
            get
            {
                return GetCollection<InvoiceDetail>(nameof(InvoiceDetails));
            }
        }
    }
}
