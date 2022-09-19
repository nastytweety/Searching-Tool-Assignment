# Searching-Tool-Assignment is an example of consuming and providing webservices. It is designed for maximum extensibility. It provides the bitcoin to usd prices from two independent brokers. The examples illustrates the use of generic repository + unit of work deisgn pattern.

Searching-Tool-Assignment requires athentication/authorization. There are two types of users. User and Admin. The database is seeded automatically when applied the latest migration. Two users are seeded in db.

UserName = "admin", Password = "Adm//assign" Role Admin

and

UserName = "user", Password = "Adm//assign" Role User

Bitstamp and Bitfindex are seeded in db plus btcusd currency. There is no need to add anything.

#Installation

Clone repository Restore NuGet Packages Open Package-Manager-Console and run Update-Database

#GitHub https://github.com/nastytweety/Searching-Tool-Assignment
