# Starting application

## Command line:
Go to project path

### Build
dotnet build

### Run
dotnet run

## Visual Studio:
Build and run NotesAPI as startup project

## Testing API:
1. Run web app from one of steps above
2. Install and open Postman


## Postman Commands:
1. GET https:/localhost:<port#>/api/Notes (Gets full list of notes)
2. GET https:/localhost:<port#>/api/Notes/{id} (Gets specific note by ID)
3. PUT https:/localhost:<port#>/api/Notes (Adds a new note)
4. POST https:/localhost:<port#>/api/Notes/{id} (Updates a new note by ID)
5. DELETE https:/localhost:<port#>/api/Notes/{id} (Deletes a note by ID)


