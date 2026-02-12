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
```
Impostare la connection string nel progetto WindowsForm (`app.config`):

```xml
	<connectionStrings>
		<add name="DefaultConnection" connectionString="Server=(localdb)\MSSQLLocalDB;Database=DemoGestionaleDb;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
	</connectionStrings>
```


## NOTA
è consigliabile eseguire un primo avvio del progetto API, inquanto è stato predisposto un seeder per la base dati.
Il seeder è pensato per istanziare il db (qualora non fosse stato creato) e generare dei dati fittizzi di testing per l'enduser
