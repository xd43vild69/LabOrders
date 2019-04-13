# LabOrders TEST 2019
 .Net Framework - .NET Core - Dapper


## Architecture

- Carvajal.DOMAIN
	- BAL: Business logic layer.
	- DTO: Data transfer objects.
- Carvajal.DATA 
	- SAL: Data acess layer.
- Carvajal.API
	- API: Web API.
- Carvajal.WEB: 
	- APP: Application client.
- Carvajal.TEST: 
	- UnitTest: Unit Test project.	

## TOOLS

- .NET Framework BACKEND : API - DAL - SAL - DTOS
- .NET Core 2.1 FRONTEND : APP-WEB 
- JS - Jquery - CSS - HTML5
- Dapper
- AutoFac
- Microsoft SQL Server

## How to run

1. Change connectionStrings:
- Carvajal.API/API


2.1 Run DDL.sql scripts in SQL FOLDER
2.2 Run DML.sql scripts in SQL FOLDER


3. Set up Carvajal.API/API & Carvajal.WEB/APP on Multi start projects.

					Run.