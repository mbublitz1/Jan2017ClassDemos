<Query Kind="Expression">
  <Connection>
    <ID>5bc27f86-caa9-44ba-ace6-5b36ffa2ea09</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from theTrack in Tracks
where theTrack.Milliseconds > 325000 && theTrack.Milliseconds < 3300000
select theTrack

//Doesn't matter what you use for name in the method sytax between statements eg. row vs item
Customers.Where(row => row.State.Equals("SP")).Select(item => item)
//This is the same as above
Customers.Where(row => row.State.Equals("SP")).Select(row => row)
//Checks for anything that does not have a state
Customers.Where(row => row.State == null).Select(row => row)