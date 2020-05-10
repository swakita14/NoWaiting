# Technical Overview: **Nowaiter (Web Api)**

## **Idea Organization**
- This would act as an intermediary for the Nowaiter mobile application (and possibly web?) It is a way for users to know the current waiting time, customer, and the overall availability of the restaurant in real time. Google Places does offer majority of the information (where I will obtain majority of the information from) and has estimates of the waiting time and the crowded hours. This web api will track the count real-time. 

## Database Schema 
*Restaurant Table*
- PK:Restaurant Id
- Derived from Google Places  
    - Name
    - Phone
    - Address
    - City
    - State
    - ZipCode
    - GooglePlacesId

*Status Table*
- PK:Availability Id
- FK:Restaurant Id
- Drive-Thru Count
- In-Store Count

*Location Table*
- PK:Location Id
- FK: Restaurant Id
- Latitude 
- Longitude


## Web API Methods
- Drive-Thru 
    - GET, POST
- In-Store
    - GET, POST
- Average Wait Time (Maybe)
    - GET

## Resource
- Google Places API: getting venue name, location, number