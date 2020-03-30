# Technical Overview: **Nowaiter**

## **Idea Organization**

**Input**:
 - Users can select two options, either checking the current status of the venue, or checking in to either the drive-in or in-store order option 

**Process**:
- Checking Status:
    - Users can enter the name of the restaurant or the venue and get a list of the venues ordered by the distances. The user can then select the **Status** option which would give the current value of how many customers are both in drive-through and in-store. This function could also provide the user with the average wait time of each customer waiting 
- Checking-In
    - Users can enter the name of the restaurant or the venue and get a list of the venues ordered by the distances. The user can then select the **Check-In** option which would then navigate them towards another page to either select drive-through or in-store pickup. After selecting either one of them, the user has a page where they can push a button once they've picked up their order.

**Output**:
- Give a current update to the potential customers so that they can see the status of the restaraunt/venue in terms of people currently waiting. Which would allow the users to make a better decision given the data. 

**Resource**:
- API
    - Google Places API: getting venue name, location, number
    - Azure WebAPI
- Database
    - Azure SQL Database: Saving results for Google Places, storing numbers of current waiting customer 