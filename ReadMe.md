# TV Shows Bookkeeping Website (demo)

Basically, this website shows a list of TV shows, and lets you edit that list.  

The idea is to get a bit familiar with technologies, interaction between them, and coming up with a decent project setup:
- Azure/cloud + ASP.NET web application
- NoSql database (MongoDB)
- General project setup (i.e. using Repository pattern, DAL)

## Project/Development Notes

This project is targeted at Azure specifically, because I leverage their ability to inject settings data from their end.  
In fact, it should be up right now, here: http://tvshowdemosite.azurewebsites.net/  
The only reason for this, is that it provides me with a nice way of open-source hosting the project on here, but also keeping _secrets_ out (e.g. database connection string) without going too far from a standard Visual Studio 2015 project setup.

### Project Prerequisites

The project should mostly work out of the box, but...  
- We depend on an external database (MongoDB).

#### Database/MongoDB

Although it shouldn't be too dificult to implement an alternative database setup, I only implemented things for MongoDB. So, with that in mind...  
We require two bits of information, **MongoDB URI** (connection string), and the **database name**.

Both pieces of information are stored in the _Web.config_ file.  
**Note:** The current values in there are for local debugging. So, your local MongoDB needs to reflect it; and be running of course. (Blame MS/Visual Studio 2015 not applying transformation on builds/debugging.)

***Azure deployment note:***  
If you want to deploy to Azure as a web app, just add your real _secret_ values (connection string, db name) in application settings for your spun up instance via the Azure portal page. **Make sure to enter the correct names for those entries, and under the right section.** ...for the hosting of the database, I'm afraid you're on your own for that one. **Note it does have to be external database if you're running on cloud, as in-memory database would not work/would be unsafe. (Probably obvious.)**