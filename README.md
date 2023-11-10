# WeSellUsers
This application was built from scratch as a take-home challenge for my employment within Richmond Day. It was built with ASP.NET MVC, Entity Framework, and Vue.js

For this challenge I was given mock data in an excel sheet and tasked with designing a database and a full stack application to manage and display the data.

Initially, I deployed the project on Azure for public use. Due to costs, it is no longer available on the web, but its source code lives on.

Below is an overview of the project solution, my thoughts, and a post-mortem. 

## The solution
Using AJAX, data is retrieved from an SQL database and processed with Vue.js. The User page displays a list of all User’s and their properties within the database. Any single property can be edited by
clicking over the text value (even if it is empty). Any time the user un-focuses a field, that field will
attempt to update if the value changed while the field was editable. Client-side validation prevents
unnecessary database calls and a second check on the server-side ensures that anything getting through is
properly processed. A User is considered valid if at least one property is not null and the email
address is legitimate. The “edit mode” pen makes all three properties of the respective User
editable. While in edit mode, a save icon appears and once clicked, reverts properties to their
read-only text state. A red x deletes the respective user after a confirmation. The filter input accepts text
and filters the users based on the selected property indicated by a dropdown. The add user
button creates a new user in the empty state that can be added to the database by clicking save once at least on property is added.

## My thoughts
I had a lot of fun with this project and overall I’m very happy with the final result. I made the users
page dynamic and seamless without complicating the UI because I wanted editing to feel natural. I
took a minimalist approach by only including the necessities and letting the icons speak for
themselves. I made sure to include visual feedback to indicate things like server processing and
valid/invalid input. I accommodated for mobile devices because the full width of a phone screen is
necessary when entering or reading text. I do recognize that autosaving fields are not the best
solution for a user management page, this functionality would be better suited for data that is frequently changed.

## What I’d improve
Optimization is an iterative process and small improvements can always be made. Barring these small
improvements, I would have liked to allow xmls or csv files to be uploaded and parsed directly into
the database. I would have also liked to implement some pagination to refine the results.
