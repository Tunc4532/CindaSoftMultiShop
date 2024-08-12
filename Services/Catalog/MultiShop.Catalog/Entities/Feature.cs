using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }

        #region Kalıtım
        //class MyClass
        //{
        //    //full property örneği metot ile de yapılabilir fakat prop ile daha işlevsel
        //    public string MyProperty
        //    {
        //        get { return MyProperty; }
        //        set => MyProperty = value;
        //    }

        //    //sanal yapılanma
        //    public virtual int MyProperty1 { get; set; }
        //}

        //class MyClass1 : MyClass
        //{
        //    //sanal yapıya müdahale 
        //    public override int MyProperty1 { get; set; }

        //}
        #endregion
    }
}
