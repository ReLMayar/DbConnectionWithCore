using System.Runtime.Serialization;

namespace DbConnectWithCore
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int productId { get; set; }
        [DataMember]
        public string productName { get; set; }
        public Shop shop { get; set; }
        [DataMember]
        public int shopId { get; set; }
    }
}
