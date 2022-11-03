namespace PaymentsReconciliation.Model
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ItemPricesRoot
    {

        public ItemPrice[] itemPricesListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ItemPrice", IsNullable = false)]
        public ItemPrice[] ItemPricesList
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
}
