# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.

##Solution:

- Analyze the requeriment and the project in general.
- Separate the all code in layers and simplify the code.
- Layers:
  Data --> Manage all actions related with the user (Read/Get & Insert into the user file)
  Dto --> Objects for request and response on the controllers.
  Interfaces --> Manage interfaces
  Model --> Object definition for Users actions.
  Services --> Manega de business logic related with the user, add validations, manage errors.
  Util --> Add definition for generic objects and functions.

##Note:
I've apply the best practices I know, SOLID principles, DRY, design patterns, Singleton.
