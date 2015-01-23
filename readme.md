# AzureMicroservicesSample

Sample system to very conceptions around microservices hosted in Azure cloud.

## Thoughts about created architecture

### Service Gateways configuration

In current version I've implemented it by assigning given port address to service and automaticaly create services address on webapplication by replacing port number. 
This solution is cool as do not require config files tith service adreses, but is probably to rigid and base on too many assumption. Work only if all services are deployed to single "cloud service".

### Queries and Commands - how to access database

I've implemented idea of "Relaxed layers" or Comands Query Segregation. Access to underlaying databases is provided both from the level of microservice and web application. But there is convention in place that only simple, straightforward Queries (Reads) can be made directly from WebApp. All Comands (changes to data and anything that is conected with logic execution) are passed through service. For this reason I'm trying to achieve concentration of domain logic in service and simplicity of other operations.
But this approach require dyscipline and complicate dependencies in system. It also require some more configuration (eg.: two applications nead connection string)

### Repositories 

Reasons to have repositories:
- can share them - only aplicable for queries, as commands are executed on server only. How often same db query is used in many places?...