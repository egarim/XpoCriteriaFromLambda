using DevExpress.Xpo;
using System;
using System.Linq;

namespace XpoCriteriaFromLambda
{
    public class InvoiceDetail : XPObject
    {
        public InvoiceDetail(Session session) : base(session)
        { }



        Product product;
        decimal unitPrice;
        decimal total;
        int qty;
        Invoice invoice;

        [Association("Invoice-InvoiceDetails")]
        public Invoice Invoice
        {
            get => invoice;
            set => SetPropertyValue(nameof(Invoice), ref invoice, value);
        }


        public int Qty
        {
            get => qty;
            set => SetPropertyValue(nameof(Qty), ref qty, value);
        }


        public decimal Total
        {
            get => total;
            set => SetPropertyValue(nameof(Total), ref total, value);
        }


        public decimal UnitPrice
        {
            get => unitPrice;
            set => SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
        }

        public Product Product
        {
            get => product;
            set => SetPropertyValue(nameof(Product), ref product, value);
        }
    }
}
