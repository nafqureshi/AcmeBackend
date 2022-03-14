# AcmeBackend

Hello All!

This is an Backend API implementation of the assigned task.

The API uses dependency injection to acheive decoupling.

Furthermore, the api uses swagger to give a more clear understanding of how to consume its endpoints.

The business logic is implemented in a separate project inside the ActivitySignupService.cs class. And so are the Entities and Abstract layers respectively.

An in memory DB using EF is used to store states. The DB entity is depicted by the User and UserActivity model classes.

To run the project, use visual studio 2019. Select Acme as the startup project and press f5 to run it.
Since this project is implemented in .net 5, it can be run on windows, linux and mac operating systems.

Tests are part of a separate project.

Please get back to me if you have any concerns and I would gladly like to clarify.

Note: There was a confusion in the way the get api call for users needed to be implemented so i have integrated 2 calls and am using just the getall call on the ui

Kind Regards,
Abdun Nafay Qureshi
