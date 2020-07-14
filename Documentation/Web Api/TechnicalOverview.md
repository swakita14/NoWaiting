# Technical Overview: **Nowaiter (Web Api)**

## **Idea Organization**
- This would act as an api for the Nowaiter mobile application (and possibly web?) It is a way for users to know the current waiting time, customer, and the overall availability of the restaurant in real time. Google Places does offer majority of the information (where I will obtain majority of the information from) and has estimates of the waiting time and the crowded hours. This web api will track the count real-time. 


## Database Schema 
*Restaurant Table*
- PK:Restaurant Id
- Derived from Google Places  
    - Name
    - Phone
    - Address1
    - Address2
    - City
    - State
    - ZipCode
    - DateUpdated
    - GooglePlacesId

*Status Table*
- PK:Status Id
- FK:Restaurant Id
- Drive-Thru Count
- In-Store Count

*Location Table*
- PK:Location Id
- FK: Restaurant Id
- Latitude 
- Longitude


## Web API Methods
- The web api methods are separated into two separate sections. One covers the status of the venue and updates the current real time count of the customers both drive through and in-store. The other covers the search method allowing a basic search of the venues by name, distance, or by simply returning an entire list. 

- Search Methods
    - GET
        - list: returns a current list of venues that are stored in the database, not ideal for the users, but mostly for testing and developing purposes

        ```c#
        localhost/api/search/list
        ```
        - name: searches venue list with similar character or name

        ```c#
        localhost/api/search/name/enternamehere
        ```

        - distance: allows a search of the restaurant nearby from closest to furthest in meters by passing in coordinates

        ```c#
        localhost/api/search/distance/lat/long
        ```

    

- Status Methods
    - POST
        - drive-thru:updates the numbers of the current drive-thru count, both when arriving and leaving

        ```c#
        localhost/api/status/drivethru/arrived/restaurantid

        localhost/api/status/drivethru/left/restaurantid
        ```

        - drive-thru:updates the numbers of the current in-store count, both when arriving and leaving

        ```c#
        localhost/api/status/instore/arrived/restaurantid

        localhost/api/status/instore/left/restaurantid
        ```


## Resource
- Google Places API

## Personal Thoughts
- This project is a simple one using the web API for .NET core and the Google Places API. Coming from a .NET Framework background, this was interesting and challenging for me personally. The toughest part of this project was probably finding a way to relate the two (Framework & Core) and see which worked on what. Personally, the .Net Core seemed easier to learn and develop. 

- Finally, if there are any bugs that are found or if any implementation I'm doing wrong, feel free to let me know! the feedback is greatly appreciated. 