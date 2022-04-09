using EnumsConstraint;


//EnumNamedValues to build a collection that is cached and reused rather than repeating the
//calls that require reflection.
var map = StoredEnums.EnumNamedValues<Rainbow>();
var map2 = StoredEnums.EnumNamedValuesV2<Rainbow>();
var map3 = StoredEnums.EnumNamedValuesV3<Rainbow>();

foreach (var pair in map)
    Console.WriteLine($"{pair.Key}:\t{pair.Value}");

foreach (var pair in map2)
    Console.WriteLine($"{pair.Key}:\t{pair.Value}");

//Get the list of strings from somewhere, like appsettings.json or the database
var list = new List<string>() { "408", "411", "412", "413", "415" };

//Convert to a set for efficient lookups later on
var statusCodeSet = list.ToSet<HttpStatusCode>();

var parsedEnum = "Red".Parse<Rainbow>();

Console.WriteLine(string.Join(Environment.NewLine, statusCodeSet));
Console.ReadLine();

