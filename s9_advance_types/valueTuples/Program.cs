var tuple1 = new Tuple<string, bool>("aaa",false);
var tuple2 = Tuple.Create(10, true);
var tuple3 = Tuple.Create(10, true);
Console.WriteLine(tuple2 == tuple3);
Console.WriteLine(tuple2.Equals(tuple3));
Console.WriteLine(tuple2.GetHashCode());
Console.WriteLine(tuple3.GetHashCode());

var valueTuple1 = new ValueTuple<int, string>(1, "bbb");
var valueTuple2 = (Number: 5,Text: "ccc");
valueTuple2.Item1 = 20;
valueTuple2.Text = "hello";
Console.ReadKey();