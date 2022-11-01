namespace PaymentsReconciliation.Models
{
    internal class Price
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class ItemPricesRoot
        {

            private ItemPricesRootItemPrice[] itemPricesListField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("ItemPrice", IsNullable = false)]
            public ItemPricesRootItemPrice[] ItemPricesList
            {
                get
                {
                    return this.itemPricesListField;
                }
                set
                {
                    this.itemPricesListField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ItemPricesRootItemPrice
        {

            private byte itemField;

            private decimal priceField;

            /// <remarks/>
            public byte Item
            {
                get
                {
                    return this.itemField;
                }
                set
                {
                    this.itemField = value;
                }
            }

            /// <remarks/>
            public decimal Price
            {
                get
                {
                    return this.priceField;
                }
                set
                {
                    this.priceField = value;
                }
            }
        }


    }
}
