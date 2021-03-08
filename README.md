# Acme Corporation - Salas Dario

Prueba realizada con .net Core y C#

# Divicion de Capas

### AcmeCorporation.CsvImporter

Proyecto principal, es del tipo consola, se implemento Nlog, Singleton e Inyeccionde Independencia

### AcmeCorporation.BussinesLogic

Capa encargada de la logica, en el ella esta el proecesamiento y obtecion del csv de AZURE.
Como asi tambien la administracion de la entidad de Stock.

### AcmeCorporation.DAL
Capa encargada de administrar la coneccion a la base, en ella se encuentra los repositorios, usa EntityFramework, el patron UnitOfWork (para la administarcion de los repositorios), ademas usamos BulkDbContextExtensions, para la insercion masiva de los achivos. 

### AcmeCorporation.Model
Capa que persiste por todas las demas capas, para los modelos que se van a utilizar en la solucion.

### AcmeCorporation.Tests
Proyecto encargado de los test Unitarios.

## Nota
Relaizice diferentes pruebas para obtimizar el proceso, termine usando Bulk para la insercion(AddRange de EntityFramework era mas lento).
Obiamente para futuro, sera mejor hacer un stored, que seria mas perfomante.
La inyeccion, nunca la habia usado desde una apliccion de Consola, no estoy seguro que sea la mejor forma, es un desafio a futuro que quiero investiga.
Para el proceso principal, el que inserta en la base, decidi dividir los archivos en batch de 1000, para evitar insertar de uno a uno, lo cual no me parecia lo correcto. De esta forma, se podria tener un control sobre que se va insertando, y a futuro, si falla un registro, no corte todo, solo un batch. Y se podria hacer un control sobre este bach que produjo la falla.
Ademas realice un Test unitario, basico, como para verificar si los procesos principales, no se usen mas de una vesz en la applicacion, asegurando, que futuro desarrollos estos modulos que son core de la alicacion, no se pueda usar mas de una vez. 

## Tecnolgias Usadas
1 - Ncapas
2 - CsvHelper
3 - Nlog
4 - DI
5 - EF - Bulk
6 - Azure Storage Blobs
7 - UnitOfWork
8 - Singleton
9 - NUnit 


