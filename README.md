# BettingSystem

.Net core app (backend) + angular 5 (frontend)

NOTE:

To create database run ef core migrations:

1. Build project
2. In console run command 'cd Path\to\BettingSystem.Infrastructure database update'
3. In console run command 'dotnet ef -s Path\to\BettingSystem.WebApp database update'

There should be some data already present.

To resolve games and generate new ones run hangire job 'GenerateAndResolveGames' which is located on URL/hangfire page and run automatically every 1 hour.
