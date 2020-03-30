# Architecture: **Nowaiter**

## Framework
- Xamarin Forms (Crossplatform)
    - Front end
        - XAML 
    - Client Server
        - ASP.NET Core 
    - Backend 
        - Azure SQL Database

## Database Schema 
*Restaurant Table*
- PK:Restaurant Id
- Derived from Google Places  
    - Name
    - Location
    - Phone Number 
    - URL
    - Rating

- Average Wait Time

*Availability Table*
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
- Average Wait Time 
    - GET
    - **How do I calculate this**

