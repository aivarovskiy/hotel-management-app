![Screenshots](https://github.com/aivarovsky/hotel-management-app/blob/main/images/screenshots.png)

# Hotel Management App

## Overview

A simple hotel management client-server desktop application developed as a semester project using C#, Windows Forms and Microsoft SQL Server. The application is designed to manage hotel bookings, guest information and bookkeeping.

## Database Schema

![Database Schema](https://github.com/aivarovsky/hotel-management-app/blob/main/images/schema.png)

## Prerequisites

- [Docker](https://docs.docker.com/get-docker) installed (required for running the Microsoft SQL Server container).

## Setup

1. Download the application files from the [Releases](https://github.com/aivarovsky/hotel-management-app/releases) page or clone this repository and build it yourself:

        git clone https://github.com/aivarovsky/hotel-management-app

    >A `init.sql` file creates 2 database users: `admin` and `guest`. You can find logins and passwords in the file and change them if needed.

2. Download the Microsoft SQL Server Docker image:

        docker pull mcr.microsoft.com/mssql/server

3. Start the Microsoft SQL Server Docker container:

    Replace `YOUR_PASSWORD_HERE` and `absolute/path/to/init.sql`.

       docker run -it --name mssql-server -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YOUR_PASSWORD_HERE" -p 1433:1433 -v absolute/path/to/init.sql:/init.sql mcr.microsoft.com/mssql/server:latest

    >The password must be at least 8 characters long and contain characters from three of the following four sets: uppercase letters, lowercase letters, digits and symbols.

4. Wair for the container to load and then stop it.

        ... The tempdb database has 8 data file(s).

5. Start the container:

        docker start mssql-server

6. Create the database and related entities:

    Replace `YOUR_PASSWORD_HERE`.

        docker exec -it mssql-server /opt/mssql-tools18/bin/sqlcmd -S localhost -l 60 -U SA -P "YOUR_PASSWORD_HERE" -C -i init.sql

7. Run the application.

## License

This project is licensed under the [**Unlicense**](https://github.com/aivarovsky/hotel-management-app/blob/main/LICENSE).