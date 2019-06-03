Video
https://www.youtube.com/watch?v=Et2khGnrIqc


Sample Code
Reading the Connection String
ConfigurationManager.ConnectionStrings[name].ConnectionString;
 

Getting Data from SQL
using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
{
    var output = connection.Query("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
    return output;
}
 

Putting Data into SQL
using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
{
    List people = new List();
    people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });
    connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
}
 

