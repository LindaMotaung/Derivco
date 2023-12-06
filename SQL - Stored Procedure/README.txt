- The script to create the Northwind database is titled "instnwnd.sql"

- In addition to the stored procedure ("pr_GetOrderSummary.sql"), I have created an ExecutionLog table that is a nice-to-have to log, audit and keep track of when the stored procedure is executed. The script to create it is in the "CREATE Table ExecutionLog.sql" file on this folder
 > I added some exception handling for validating input data and adding overall robustness
 > I used concatenation and formatting to work with dates. The tests provided made use of strings for the start and end date input parameters
 > Using left join to handle possible null orders (orders with no customers)
 > Made use of grouping and aggregation functions to sum records into summary groups for the result set
 > Made use of sorting
 > It was noted that the entities in the Northwind database were not normalized so I did not make an effort to do their normalization since the schema came already provided for this use case
 > The stored procedure is using parameterized queries which will safeguard it against any possibility of a SQL injection thus adding an extra layer of security
 > Considering that the data set was quite reletively small, there were no performance bottlenecks to consider
 > The tables in the Northwind database have appropriate clustered indexing 

- The Web API component of the project I created with ASP.Net Core using Clean Architecture, CQRS, SOLID Principles and the Mediator pattern. My choice for this design was as follows:
  > I wanted to design for scalability. In the event that the business wants to enhance the requirement to not only allow russian roulette but also black jack for instance. Hence the Bet Type feature
  > Implemeneted detailed seperation of concern. The API knows that it needs to do something. How it's supposed to do it is not concerned with that. That abstraction is facilitated through the mediator pattern. This makes the application truly closed for modification and open for extension. 
  > Made use of CQRS design pattern to control how the system should seperate commands that manage an object's state compared to queries that are responsible for retrieving data. The models used for writing data (placing a bet) differ than the models used for reading data (e.g a bettor's allocated bets)
  > Clean architecture ensures that each layer in the system has a single responsibility and should only have one reason to change i.e changing the email service (infrastructure layer) should not affect the bet service (applicaiton layer)

