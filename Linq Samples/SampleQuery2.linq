<Query Kind="Statements">
  <Connection>
    <ID>5bc27f86-caa9-44ba-ace6-5b36ffa2ea09</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//These queries are C# statements ^ see here, the statements below need to be written in proper C# syntax

var results = from x in Albums
where x.Artist.Name.Contains("Black")
orderby x.ReleaseYear descending
select x;

//Dump is used in Linqpad to return the results from the variable.
//.Dump() is a LinqPad method, NOT C# 

results.Dump(); 

var methodResults = Albums
   .Where (x => x.Artist.Name.Contains ("Black"))
   .OrderByDescending (x => x.ReleaseYear);
results.Dump();