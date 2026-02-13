# Architettura della soluzione

La soluzione è strutturata seguendo un approccio **Clean Architecture semplificato**, con l’obiettivo di mantenere il codice chiaro, manutenibile ed estendibile, evitando over-engineering.

## Struttura generale

src/
Backend/
Gestionale.Api
Gestionale.Application
Gestionale.Domain
Gestionale.Infrastructure

Frontends/
Gestionale.Webapp (Mudblazor Server)
Gestionale.WinForms

Shared/
Gestionale.Shared


## Backend

### Domain
Contiene il modello di dominio:
- Entità principali (`Cliente`, `Ordine`)
- Relazioni tra entità
- Regole di base del dominio

Non dipende da framework o librerie esterne.

### Application
Contiene la logica applicativa:
- Servizi applicativi
- Interfacce dei repository
- Gestione dei casi d’uso

Questo layer orchestral le operazioni senza conoscere i dettagli tecnici.

### Infrastructure
Implementa gli aspetti tecnici:
- Accesso al database tramite Entity Framework Core
- Implementazioni dei repository
- Configurazioni delle entità

Dipende dai layer Domain e Application.

### API
Espone le funzionalità tramite REST API:
- Minimal API
- Mapping tra DTO e modelli di dominio
- Gestione HTTP e status code

La logica di business non è contenuta negli endpoint.

## Shared
Contiene i DTO condivisi tra:
- Backend API
- Frontend Blazor Server

I DTO rappresentano il contratto di comunicazione tra i sistemi.

## Frontend Blazor Server
Applicazione web che:
- Consuma esclusivamente le REST API
- Non accede direttamente al database
- Utilizza servizi dedicati per le chiamate HTTP
- Organizza la UI in componenti riutilizzabili

## Frontend WinForms
Applicazione desktop legacy-style che:
- Accede direttamente al database
- Utilizza `Microsoft.Data.SqlClient`
- Non passa dalle API (scelta consapevole in base ai requisiti)

Questa separazione simula uno scenario reale con sistemi legacy affiancati a soluzioni moderne.

## Considerazioni finali
La struttura scelta privilegia:
- chiarezza
- separazione delle responsabilità
- facilità di estensione futura

Le scelte architetturali sono volutamente pragmatiche e orientate a contesti reali.
