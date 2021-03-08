## Acme Corporation - Salas Dario
Prueba realizada con .net Core y C#
## División de Capas
### AcmeCorporation.CsvImporter
Proyecto principal, de tipo consola. Se implementó Nlog, Singleton e Inyección de Dependencias
### AcmeCorporation.BussinesLogic
Capa encargada de la lógica, en el ella está el procesamiento y obtención del csv de AZURE. Como asi tambien la administración de la entidad de Stock.
### AcmeCorporation.DAL
Capa encargada de administrar la conexión a la base de datos. En ella se encuentran los repositorios. Usa EntityFramework, el patrón UnitOfWork (para la administración de los repositorios), además usamos BulkDbContextExtensions, para la inserción masiva de los registros.
### AcmeCorporation.Model
Capa que persiste por todas las demás, para los modelos que se van a utilizar en la solución.
### AcmeCorporation.Tests
Proyecto encargado de los tests Unitarios.
## Nota
Realicé diferentes pruebas para optimizar el proceso. Terminé usando Bulk para la inserción (AddRange de EntityFramework era más lento). Para futuro, me gustaría explorar la alternativa de utilizar un Stored Procedure para hacer la inserción ya que asumo que puede ser más performante. 

Nunca había usado antes inyección de dependencias desde una aplicación de Consola. No estoy seguro de haberlo implementado de la mejor forma, es un desafío a futuro que quiero investigar.
Para el proceso principal, el que inserta en la base de datos, decidí dividir los archivos en batches de 1000 registros, para evitar insertar de uno a uno, lo cual no me parecía correcto. 

De esta forma, se podría tener un control sobre qué se va insertando, y a futuro, si falla un registro, no detenga el proceso, sino un sólo batch y hacer un control sobre el mismo.
Además realicé un Test unitario básico para verificar que los procesos principales que se llamen sólo una vez, asegurando que el los módulos core que son: Descarga y Proceso del Archivo, siempre se produzcan. Por cuestiones de tiempo, no llegué a desarrollar el resto de tests cases que tenía pensado. Algunos de ellos eran: 
*	Que cuando los datos de Azure sean correctos, la descarga del archivo se produzca correctamente
*	Que cuando los datos de Azure sean incorrectos, no se produzca descarga
*	Que el procesamiento del archivo se procese correctamente, moqueando con Moq, la descarga del mismo
*	Que cuando el archivo tenga al menos un registro, se realice una inserción en la base de datos
*	Otros. 

En la carpeta **Doc**, están los script de creación de la base, como así también una copia del archivo csv, para hacer un test unitario de la carga de la misma.

## Tecnolgias Usadas
* Ncapas 
* CsvHelper 
* Nlog 
* DI 
* EF - Bulk 
* Azure Storage Blobs 
* UnitOfWork 
* Singleton 
* NUnit

