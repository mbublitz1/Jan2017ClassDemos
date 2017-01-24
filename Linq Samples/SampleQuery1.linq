<Query Kind="Expression">
  <Connection>
    <ID>5bc27f86-caa9-44ba-ace6-5b36ffa2ea09</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Albums
where x.Artist.Name.Contains("Black")
orderby x.ReleaseYear descending
select x
//Method syntax

Albums
   .Where (x => x.Artist.Name.Contains ("Black"))
   .OrderByDescending (x => x.ReleaseYear) //Lambda syntax