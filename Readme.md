# Assignment

Your task is to add a new feature to our existing Guest Book application.

This feature is a new page to display a gallery of dog pictures & videos from https://random.dog/woof.json.

## Backend

- Create a new database table to store the URL of the media items in the gallery (follow the existing convention)
- Add a new route that fetches 8 new results from https://random.dog/woof.json and adds them to the database table created above
- There is a maximum of 24 media items allowed to be stored in the database. In the event of approaching this limit you should purge the 8 oldest records before adding the 8 new.
- Add a new route that returns the media items stored in the database

## Frontend

- Create a new page to display the gallery of dogs
- The page should be responsive:
  - For desktop there should be 4 results to a row
  - For mobile there should be 1 result per row
- There should be a button to allow the user to fetch a new set of 8 random dogs
- The gallery will initially be empty until the user clicks the button for the first time
- The page will need support common formats such as png, jpg, gif, mp4 and webm results
- Any videos should play automatically

## Notes

- You'll also notice for the sake of simplicity we're not worrying about database versioning and migrations (we'll likely discuss approaches to this you've used in the past during a subsequent technical interview).

## Getting Started

- Bring up the Postgres database by running `docker-compose up`.
- Refer to the respective readme's for starting the backend and frontend.
- We recommend making sure you're able to run the app and that the guestbook feature is working before beginning to add your new feature.
