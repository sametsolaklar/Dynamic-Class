using DynamicClass;
using static DynamicClass.DynamicClassProperty;

var fields = new List<Temp>() {
            new Temp("ID", typeof(int)),
            new Temp("NAME", typeof(string)),
            new Temp("SURNAME", typeof(string))
        };
dynamic obj = new DynamicClassProperty(fields);
obj.ID = 123456;
obj.NAME = "SAMET";
obj.SURNAME = "SOLAKLAR";
Console.WriteLine(obj.ID);     //123456
Console.WriteLine(obj.NAME);   //SAMET
Console.WriteLine(obj.SURNAME);    //SOLAKLAR