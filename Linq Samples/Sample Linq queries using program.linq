<Query Kind="Program">
  <Connection>
    <ID>5bc27f86-caa9-44ba-ace6-5b36ffa2ea09</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	//find artists who have a C in their name, order alphabetically
	
	//assume the user entered a partial nave of an artist
	//on a web form on a web page and submitted the string to my controller
	//as a parameter
	
	var partialName = "C";
	
	//use a user defined class to select the specified fiels
	//off the row instance of Artists
	var results = from x in Artists
				  where x.Name.Contains(partialName)
				  orderby x.Name
				  select new ArtistList
				  {
				  		ArtistId = x.ArtistId,
						Name = x.Name
				};
	results.Dump();
}

// Define other methods and classes here
public class ArtistList
{
	public int ArtistId { get; set; }
	public string Name { get; set; }
}
