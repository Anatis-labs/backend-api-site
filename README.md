# backend-api-site
backend for the api site.


this is the backend of the project https://github.com/Anatis-labs/api-site

this backend uses dot.net core and channels a open api from:
https://www.freetogame.com/api-doc

the backend takes in the data and formats it so it can be sent over to the frontend in order to be displayed.

When you start the application it will open a browser, in the browser you will see the port that you might need to change in the front end (in the url bar example:"https://localhost:44392/swagger").
Its the "https://localhost:44392" part that you might need to change in the frontend section.

(there is instructions in the front end's readme file: https://github.com/Anatis-labs/api-site/blob/main/README.md)

It also contains a cashe method in order to avoid fetching the same data over and over again.

I have mainly used the S method of the solid principles:

S - Single-responsiblity Principle

My classes only have 1 job, and that is to map data nothing more nothing less.
(They work as models for the controllers.)

My controllers on the other hand work on the 
Open-Closed Principle

they are open for extentions but they cant be modified by any other part of the code.