[![FTask of branch hao](https://github.com/nnhao14102000/FTask/actions/workflows/hao-ci-cd.yaml/badge.svg)](https://github.com/nnhao14102000/FTask/actions/workflows/hao-ci-cd.yaml)

# FTask

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
[Docker](https://docs.docker.com/get-docker/)

[Postman](https://www.postman.com/downloads/)

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

- Test API with PostMan

![Test ](https://github.com/nnhao14102000/FTask/blob/hao/Document/Images/TestApiWithPostMan.png?raw=true "Test with Postman")


#### ©  *Nguyen Nhut Hao 2021/07/12*