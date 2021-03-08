## Acme Corporation - Salas Dario
Prueba realizada con .net Core y C#
## Divicion de Capas
### AcmeCorporation.CsvImporter
Proyecto principal, es del tipo consola, se implementó Nlog, Singleton e Inyección de Independencia
### AcmeCorporation.BussinesLogic
Capa encargada de la lógica, en el ella está el procesamiento y obtención del csv de AZURE. Como asi tambien la administración de la entidad de Stock.
### AcmeCorporation.DAL
Capa encargada de administrar la conexión a la base, en ella se encuentra los repositorios, usa EntityFramework, el patrón UnitOfWork (para la administración de los repositorios), ademas usamos BulkDbContextExtensions, para la inserción masiva de los archivos.
### AcmeCorporation.Model
Capa que persiste por todas las demás capas, para los modelos que se van a utilizar en la solución.
### AcmeCorporation.Tests
Proyecto encargado de los test Unitarios.
## Nota
Realice diferentes pruebas para optimizar el proceso, termine usando Bulk para la inserción (AddRange de EntityFramework era mas lento). Obviamente para futuro, será mejor hacer un stored, que sería más perfomante. La inyección, nunca la había usado desde una aplicación de Consola, no estoy seguro que sea la mejor forma, es un desafío a futuro que quiero investiga. Para el proceso principal, el que inserta en la base, decidí dividir los archivos en batch de 1000, para evitar insertar de uno a uno, lo cual no me parecía lo correcto. De esta forma, se podria tener un control sobre que se va insertando, y a futuro, si falla un registro, no corte todo, solo un batch. Y se podría hacer un control sobre este bach que produjo la falla. Ademas realice un Test unitario, básico, como para verificar si los procesos principales, no se usen más de una vez en la aplicación, asegurando, que futuro desarrollos estos módulos que son core de la aplicación, no se pueda usar más de una vez.
## Tecnolgias Usadas
1 - Ncapas 2 - CsvHelper 3 - Nlog 4 - DI 5 - EF - Bulk 6 - Azure Storage Blobs 7 - UnitOfWork 8 - Singleton 9 - NUnit
