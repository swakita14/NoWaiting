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
- Restaurant Id
- Derived from Google Places  
    - Name
    - Location
    - Phone Number 
    - URL
    - Rating
- Drive-Thru Count
- In-Store Count
- Average Wait Time

## Web API Methods
- Drive-Thru 
    - GET, POST, DELETE
- In-Store
    - GET, POST, DELETE
- Average Wait Time 
    - GET
    - **How do I calculate this**

