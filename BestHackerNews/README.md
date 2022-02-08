# Hacker News Best 20

Launch the project and the browser will open the "best20" route automatically.
The solution makes use of memory cache ir order to minimize api calls.
Cache has a expiration of 30 seconds. After expiration, api will be called again.

http://localhost/best20