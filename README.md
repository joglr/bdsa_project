# BDSA Project

![Node.js CI](https://github.com/joglr/bdsa_project/workflows/Node.js%20CI/badge.svg) ![.NET Core](https://github.com/joglr/bdsa_project/workflows/.NET%20Core/badge.svg)

## Getting started

To spin up a mssql server on docker

```
$password = New-Guid

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

$connectionString = "Server=
```

TODO: This should be stored in user secrets
https://github.com/ondfisk/BDSA2020/blob/db9ca8a50839a7080be6dda004fcf47192960ec8/Lecture04/Notes.md

## Testing

C# tests are run automatically by GitHub Actions
