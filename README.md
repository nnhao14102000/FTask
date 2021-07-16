[![FTask of branch hao](https://github.com/nnhao14102000/FTask/actions/workflows/hao-ci-cd.yaml/badge.svg)](https://github.com/nnhao14102000/FTask/actions/workflows/hao-ci-cd.yaml)

# FTask - Task Management

## Technology and tools

1. .NET 5 Web API
2. C#
3. Visual Studio 2019
4. Git
5. Docker
6. Postman for test API

## Requirement for local set up

1. [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) 
2. [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3. [Visual studio Code](https://code.visualstudio.com/)

### Or
1. [Visual Studio 2019 ](https://visualstudio.microsoft.com/downloads/)
2. [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Or 
1. [Docker](https://docs.docker.com/get-docker/)
2. [Postman](https://www.postman.com/downloads/)

## Run in local
You just run project, ... Database will be automatic create 

1. Run with VSCode
![Open Terminal](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/OpenTerminalInVsCode.png?raw=true "Open Terminal in vscode")
![Run ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/RunInVSCode.png?raw=true "Run with command")

2. Run with Visual Studio
![Run ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/RunInVisualStudio.png?raw=true "Run in visual studio")

3. Run with Docker
- Make sure that in the directory have docker-compose.yml file
![Run ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/ShowFileDockerCompose.png?raw=true "Run in visual studio")

- Make sure that you are install Docker, and turn on Docker

Run this command

`docker compose up --build`
![Run ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/RunDocker.png?raw=true "Run Docker")

- If success, in terminal will like this: 
![Success Run Docker ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/DockerRunSuccessTerminal.png?raw=true "Run Docker Success view in terminal")

- And in Docker Desktop will like this: 
![Run ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/DockerRunSuccessDockerDesktop.png?raw=true "Run Docker")

4. Test API

- With Swagger (Not support if run with Docker)
![Test ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/TestApiWithSwagger.png?raw=true "Test with Swagger")


- With Postman
![Test ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/TestApiWithPostMan.png?raw=true "Test with Postman")

## Database 

1. FTask Database 
![Diagram ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/FTaskDBDiagram.png?raw=true "FTask Database Diagram")

2. FTask Authentication Database (Support by Microsoft Identity)
![Diagram ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/FTaskAuthDBDiagram.png?raw=true "FTask Auth Database Diagram")

### Note

1. After all requirement satisfy, just run as instruction, database will automatic create

2. Or If you want have a Database with full data, We support a script of FTask database in FTask.Database project

3. If you use docker, may be when run `docker compose up --build` have this error:
![Docker Error ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/DockerErrorSqlDb.png?raw=true "Docker error when run")

Don't worry about that just run again... this error cause be cause the mssql of docker is not stable.
May be you need run one or two or three times...

4. If you run with VScode, or Visual Studio at local, Notice name of sql server in connection strings

- In code `Server=.` I use `.` for every server existed in local:
![Name of Server ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/ConnectionString.png?raw=true "Name of server")

- If have error occur with this server name, may by you replace `.` by `Server=[your server name]`
For example:
![Name ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/ServerName.png?raw=true "Server name")
![Name ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/NewServerName.png?raw=true "New Server name")


#### ©  *Nguyen Nhut Hao 2021/07/12*