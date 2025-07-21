# Dukcapil

A fullstack project with features, data and functionality based on the Indonesian Civil Registry. The data tables are split into all the document that are commonly held by Indonesia citizen and the authorization of the program is split into local and provincial officer.<br>
**This Project is Done - With few upgrades in mind**

## Features

The features of this project will be based on the available roles and their authorization

- local officer (Main Feature)
  - CRUD operation of all the citizen document
- Provincial officer (Will be developed later)
  - Managing local officer account
  - Reading logs of all local officer action

<p align="right">(<a href="#tabel-dokumen">DB Document Diagram</a>)</p>

## Built With

Here are some of the major framework i used to build this project

- ![React](https://img.shields.io/badge/React-%2320232a.svg?logo=react&logoColor=%2361DAFB)
- ![Material-UI](https://img.shields.io/badge/Material%20UI-007FFF?style=for-the-badge&logo=mui&logoColor=white)
- ![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff)
- ![Microsoft SQL Server](https://custom-icon-badges.demolab.com/badge/Microsoft%20SQL%20Server-CC2927?logo=mssqlserver-white&logoColor=white)
- ![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=fff)

## Getting Started

To run this project you will need to clone this project and have this installed in your PC

- .NET
- NPM

### Installation

These are the steps to install the dependencies for the project

1. Got to the project directory.
2. Run Docker

```bash
  cd Backend
  docker-compose up
```

3. Open new terminal on the project directory (--seed command on the dotnet run can take args <number>)

```bash
  cd Backend
  dotnet ef database update
  dotnet run --seed 10
  dotnet run
```

4. Install dependencies and run frontend

```bash
  cd ../frontend
  npm install
  npm run dev
```

## Roadmap

Here are the list of steps to build all the main features

- [x] Prototype The Frontend
  - [x] Establish Frontend Template
  - [x] Establish Frontend Theme
- [x] Prototype The Backend
  - [x] Build And Migrate the Database
  - [x] Create Domain and Application layer
  - [x] Create Seeder Program for DB.
- [x] Upload to Git with the Readme
- [x] Restructure The Backend To Apply with Clean Architecture
  - [x] Implement the Application and Presentation the Right Way
  - [x] Implement internal Error handler middleware
  - [x] Implement Badrequest Extender

Here are the new feature taht will be added later

- [ ] Implement Authorization Into the Project
  - [ ] Design the User and Authorization Table
  - [ ] Implement ABAC Middleware for The Project
  - [ ] Implement Create and Update function to User
- [ ] Implement a Logging system to record all Database Activity
- [ ] Implement Frontend for the Highlighted Important API endpoint
- [ ] Create Unit and Integration test for he Project
- [ ] Create A Higher Level of Authorization
  - [ ] Implement Features to Manage Authorization
  - [ ] Implement Features to Manage All Table
  - [ ] Implement Highest Authorization to Manage Local and Provincial Officer Action

<a id="tabel-dokumen"></a>

### Database Diagram

![Diagram](https://raw.githubusercontent.com/kennylisal/Dukcapil/refs/heads/master/image/db-diagram.png)

### Contact me

Email : kennylisal5@gmail.com <br>
Linkedin : https://www.linkedin.com/in/kenny-handy-lisal/
