# Istruzioni per l’esecuzione

## Prerequisiti
- .NET SDK 10.0.x
- .NET Framework 4.8.1
- Visual Studio 2022 (o superiore)
- SQL Server (LocalDB o istanza dedicata)

## Configurazione Database
Impostare la connection string nel progetto API (`appsettings.json`):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DemoGestionaleDb;Trusted_Connection=True;"
}
