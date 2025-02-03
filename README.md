This will send emails over 3MB using Graph. Its a WinForm app using C# and the Graph 4.0 API.
You will need to create an Applicatoin registration for oAuth App flow and grant create and send permissions and do an admin grant for this to work.
Pull in Azure.Identity and Microsoft.Graph Nuget packages.
You will need a large file if you want to test for files above 3MB - pictures work well for this.
