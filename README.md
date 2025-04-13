# 📝 Assignment: Todo application

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-5C2D91?logo=.net&logoColor=white)
![Platforms](https://img.shields.io/badge/platform-%20Android%20-lightgrey)
![.NET Web API](https://img.shields.io/badge/%20Web_API-5C2D91?logo=.net&logoColor=white)
[![License](https://img.shields.io/badge/license-MIT-blue)](LICENSE)

A .NET MAUI Android based Todo list management application, implementing MVVM design pattern with .NET Web API backend.

![App Screenshot](docs/Todo\List.png)

## ✨ App Features

- **ToDoList Page**:
  - Calls the REST APIs for, Fetching, Deleting, Updating status for the todo list.
  - Pull to refresh to getting latest todo items.
  - Long Press event for Edit, Delete Items. Navigates to the Update page on edit option.
  - Todo status switch updates API on toggle.
  - List item navigates to the view todo details page.

- **AddToDo/UpdateToDo Page**:
  - Calls the REST APIs for Adding or Updating the todo list item.
  - Same Page and ViewModel is used for both the Add/Update operations.
  - Contains necessary validations.

- **Display ToDo Page**:
  - Displays the selected Todo item.

## ✨ Key highlights

  - MVVM architecture
  - Dependency Injection
  - In Memory Entity-Framework
  - xUnit Tests

## 🚀 Development setup used:
- .NET 9 SDK
- JetBrains Rider IDE
- Android SDK
- Microsoft JDK 17


## 🧪 Testing:

- **.NET MAUI:** Tested on android emulator via IDE.
  - Used baseUrl: `http://10.0.2.2:5270/api/todo` to consume the locally hosted APIs. For more info, please [refer](https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-9.0#android).
- **WebApi:** Tested on localhost using swagger.
- **Integration Test(debug):** Launch both the projects from the IDE simultaneously to get the APIs working and get tested from the emulator.
