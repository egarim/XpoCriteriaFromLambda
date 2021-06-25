using DevExpress.Xpo;
using System;
using System.Linq;

namespace XpoCriteriaFromLambda
{
    public class Product : XPObject
    {
        public Product(Session session) : base(session)
        { }




        string code;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }
    }
}
