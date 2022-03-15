Data Modification and Composition Notes:
* To keep in line with C# naming conventions, I renamed all the object members to be PascalCased.
* Because it didn't make sense, I added a Company to the Reservation object, and added sample data to the Guests.json so each reservation has a company attached to it.
* I used a standard MVC pattern to build this application.
* My main process to verify the correctness was to manually debug as well as use NUnit tests (which did break, more later)
* I wrote this in C#/.NET because it's strongly typed and my most comfortable language. Because Kipsu is mostly a web based application, I would have preferred using JavaScript or TypeScript, favoring TypeScript since it's strongly typed, but didn't want to spend a great number of hours learning a language and its debugging techniques.
* Besides entirely writing this with TypeScript, I'd spend more time fixing the weird issue with the NUnit tests. It is favoring looking in the AppData folder for the files, instead of the project folder. I got it working once, which is how I know the tests worked properly and showed my data layer worked.
* I did my best to comment code blocks that aren't clear with simple reading to explain what is going on.

To run the program, simply run the Run application shortcut.
Close the application either by right clicking it on your task bar and choosing "Close" or pressing the X in the corner.