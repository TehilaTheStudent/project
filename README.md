# COVID-19 Management System for HMO Members

## Overview
This project is designed to manage COVID-19 data for Health Maintenance Organization (HMO) members. It includes a server-side application developed in C# and a client-side application built with React.

## Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Installation](#installation)

## Features
### Server-Side
- Manages information about HMO members, including COVID-19 infections and vaccinations.
- Developed in C# with a SQL Server database using Entity Framework.
- Exposes GET and POST requests for data retrieval and access.
- Located in the **serverSide** folder.

### Client-Side
- Built with React to provide a user-friendly interface.
- Allows users to upload and display images related to COVID-19.
- Provides a summary view of COVID-19 information.
- Located in the **clientSide** folder.

## Technologies
- **Server-Side:**
  - C#
  - .NET Core
  - SQL Server
  - Entity Framework

- **Client-Side:**
  - React
  - JavaScript

## Installation

### Server-Side
1. Clone the repository:
   ```bash
   git clone https://github.com/TehilaTheStudent/project.git

2. Navigate to the server directory:
   ```bash
   cd project/serverSide
3. Open the solution in Visual Studio 2022.

4. Ensure you have the .NET Core SDK 6.0 installed.

5. Open the Package Manager Console and run:
   ```bash
   update-database
6. Run the application:
   ```bash
   dotnet run


### Client-Side
1. Navigate to the client directory:
   ```bash
   cd project/clientSide/my-react-app

2. Open the project in Visual Studio Code.

3. Install dependencies:
   ```bash
   npm install

4. Start the React application:
   ```bash
   npm start
