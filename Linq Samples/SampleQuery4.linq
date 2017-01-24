<Query Kind="Expression">
  <Connection>
    <ID>5bc27f86-caa9-44ba-ace6-5b36ffa2ea09</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Artists
where x.Name.Contains("C")
orderby x.Name
select new {
	x.ArtistId,
	x.Name
}

//Could put in a class name in the above code like below if the class exists of course
//select new className {
//	x.ArtistId,
//	x.Name
// }

//Changes the titles at the titles of a column but it also changes the attributes.
from x in Artists
where x.Name.Contains("C")
orderby x.Name
select new {
	Mary = x.ArtistId,
	Fred = x.Name
}